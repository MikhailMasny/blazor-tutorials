using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Masny.Blazor.ClientSide.Helpers
{
    public class FakeBackendHandler : HttpClientHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var users = new[] { new { Id = 1, Username = "test", Password = "test", FirstName = "Test", LastName = "User" } };
            var path = request.RequestUri.AbsolutePath;
            var method = request.Method;

            return path switch
            {
                "/users/authenticate" when method == HttpMethod.Post => await authenticate(),
                "/users" when method == HttpMethod.Get => await GetFakeUsers(),
                _ => await base.SendAsync(request, cancellationToken)
            };

            async Task<HttpResponseMessage> authenticate()
            {
                var bodyJson = await request.Content.ReadAsStringAsync();
                var body = JsonSerializer.Deserialize<Dictionary<string, string>>(bodyJson);
                var user = users.FirstOrDefault(x => x.Username == body["username"] && x.Password == body["password"]);

                return user == null
                    ? await ReturnError("Username or password is incorrect")
                    : await ReturnOk(new
                {
                    Id = user.Id,
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Token = "fake-jwt-token"
                });
            }

            async Task<HttpResponseMessage> GetFakeUsers()
            {
                return !isLoggedIn() 
                    ? await ReturnUnauthorized() 
                    : await ReturnOk(users);
            }

            async Task<HttpResponseMessage> ReturnOk(object body)
            {
                return await ReturnJsonResponse(HttpStatusCode.OK, body);
            }

            async Task<HttpResponseMessage> ReturnError(string message)
            {
                return await ReturnJsonResponse(HttpStatusCode.BadRequest, new { message });
            }

            async Task<HttpResponseMessage> ReturnUnauthorized()
            {
                return await ReturnJsonResponse(HttpStatusCode.Unauthorized, new { message = "Unauthorized" });
            }

            async Task<HttpResponseMessage> ReturnJsonResponse(HttpStatusCode statusCode, object content)
            {
                var response = new HttpResponseMessage
                {
                    StatusCode = statusCode,
                    Content = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json")
                };

                await Task.Delay(500);

                return response;
            }

            bool isLoggedIn()
            {
                return request.Headers.Authorization?.Parameter == "fake-jwt-token";
            }
        }
    }
}
