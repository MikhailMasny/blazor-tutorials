using Masny.Blazor.ClientSide.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Masny.Blazor.ClientSide.Code
{
    //[Authorize(Roles = "Role")]
    public class PostRequestCode : ComponentBase
    {
        protected PostResponse Response;
        protected string ResponseErrorMessage;

        [Inject]
        public HttpClient HttpClient { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://jsonplaceholder.typicode.com/posts");
            var postBody = new
            {
                title = "foo",
                body = "bar",
                userId = 1,
            };
            request.Content = new StringContent(JsonSerializer.Serialize(postBody), Encoding.UTF8, "application/json");

            using var httpResponse = await HttpClient.SendAsync(request);

            if (!httpResponse.IsSuccessStatusCode)
            {
                ResponseErrorMessage = httpResponse.ReasonPhrase;
                return;
            }

            Response = await httpResponse.Content.ReadFromJsonAsync<PostResponse>();
        }
    }
}
