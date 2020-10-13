using Masny.Blazor.ClientSide.Interfaces;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace Masny.Blazor.ClientSide.Code
{
    public class MainCode : ComponentBase, IDisposable
    {
        protected List<string> messages = new List<string>();

        [Inject]
        private IMessageService MessageService { get; set; }

        protected override void OnInitialized()
        {
            MessageService.OnMessage += MessageHandler;
        }

        public void Dispose()
        {
            MessageService.OnMessage -= MessageHandler;
        }

        private void MessageHandler(string message)
        {
            if (message != null)
            {
                messages.Add(message);
            }
            else
            {
                messages.Clear();
            }

            StateHasChanged();
        }
    }
}
