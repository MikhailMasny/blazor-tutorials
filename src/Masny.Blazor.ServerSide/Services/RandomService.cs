using System;

namespace Masny.Blazor.ServerSide.Services
{
    public class RandomService
    {
        public Guid RandomGuid { get; } = Guid.NewGuid();
    }
}
