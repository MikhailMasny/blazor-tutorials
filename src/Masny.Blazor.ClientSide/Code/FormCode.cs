using Masny.Blazor.ClientSide.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Text.Json;

namespace Masny.Blazor.ClientSide.Code
{
    public class FormCode : ComponentBase
    {
        protected FormModel model = new FormModel();
        protected EditContext editContext;

        protected List<string> InputSelectList { get; set; } = new List<string>
        {
            string.Empty,
            "Mr",
            "Mrs",
            "Miss",
            "Ms"
        };

        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        protected override void OnInitialized()
        {
            editContext = new EditContext(model);
        }

        protected void HandleValidSubmit()
        {
            var modelJson = JsonSerializer.Serialize(model, new JsonSerializerOptions { WriteIndented = true });
            JSRuntime.InvokeVoidAsync("alert", $"Your data:\n\n{modelJson}");
        }

        protected void HandleReset()
        {
            model = new FormModel();
            editContext = new EditContext(model);
        }
    }
}
