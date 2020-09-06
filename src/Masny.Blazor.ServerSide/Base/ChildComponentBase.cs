using Masny.Blazor.ServerSide.Services;
using Microsoft.AspNetCore.Components;

namespace Masny.Blazor.ServerSide.Base
{
    public class ChildComponentBase : ComponentBase
    {
        [Inject]
        protected RandomService RandomService { get; set; }

        protected bool IsDarkTheme;
        protected string AlertTheme => IsDarkTheme ? "dark" : "light";

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected override void OnInitialized()
        {
            IsDarkTheme = true;
        }
    }
}
