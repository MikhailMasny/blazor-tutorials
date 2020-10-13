using Masny.Blazor.ClientSide.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Masny.Blazor.ClientSide.Code
{
    public class MessageCode : ComponentBase
    {
        [Inject]
        private IMessageService MessageService { get; set; }

        [Parameter]
        public string SomeText { get; set; }

        protected void SendMessage()
        {
            MessageService.SendMessage("Simple text!");
        }

        protected void ClearMessages()
        {
            MessageService.ClearMessages();
        }
    }
}
