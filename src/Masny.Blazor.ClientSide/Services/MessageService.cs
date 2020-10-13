using Masny.Blazor.ClientSide.Interfaces;
using System;

namespace Masny.Blazor.ClientSide.Services
{
    public class MessageService : IMessageService
    {
        public event Action<string> OnMessage;

        public void SendMessage(string message)
        {
            OnMessage?.Invoke(message);
        }

        public void ClearMessages()
        {
            OnMessage?.Invoke(null);
        }
    }
}
