using Microsoft.AspNetCore.Components;

namespace Masny.Blazor.ServerSide.Code
{
    public class ChildComponentBase : ComponentBase
    {
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
