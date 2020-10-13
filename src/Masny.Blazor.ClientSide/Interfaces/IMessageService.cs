using System;

namespace Masny.Blazor.ClientSide.Interfaces
{
    public interface IMessageService
    {
        event Action<string> OnMessage;
        void SendMessage(string message);
        void ClearMessages();
    }
}
