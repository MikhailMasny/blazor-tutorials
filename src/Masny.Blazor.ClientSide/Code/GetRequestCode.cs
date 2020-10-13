using Masny.Blazor.ClientSide.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Masny.Blazor.ClientSide.Code
{
    //[Authorize(Roles = "Role")]
    public class GetRequestCode : ComponentBase
    {
        protected IEnumerable<PostResponse> Response;
        protected string ResponseErrorMessage;

        [Inject]
        public HttpClient HttpClient { get; set; }

        protected override async Task OnInitializedAsync()
        {
            using var httpResponse = await HttpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");

            if (!httpResponse.IsSuccessStatusCode)
            {
                ResponseErrorMessage = httpResponse.ReasonPhrase;
                return;
            }

            Response = await httpResponse.Content.ReadFromJsonAsync<IEnumerable<PostResponse>>();
        }
    }
}
