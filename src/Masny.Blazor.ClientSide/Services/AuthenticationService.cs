using Masny.Blazor.ClientSide.Interfaces;
using Masny.Blazor.ClientSide.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Masny.Blazor.ClientSide.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IHttpService _httpService;
        private readonly NavigationManager _navigationManager;
        private readonly ILocalStorageService _localStorageService;

        public AuthenticationService(IHttpService httpService,
                                     NavigationManager navigationManager,
                                     ILocalStorageService localStorageService)
        {
            _httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
            _navigationManager = navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));
            _localStorageService = localStorageService ?? throw new ArgumentNullException(nameof(localStorageService));
        }

        public User User { get; private set; }

        public async Task Initialize()
        {
            User = await _localStorageService.GetItem<User>("user");
        }

        public async Task Login(string username, string password)
        {
            User = await _httpService.Post<User>("/users/authenticate", new { username, password });
            await _localStorageService.SetItem("user", User);
        }

        public async Task Logout()
        {
            User = null;
            await _localStorageService.RemoveItem("user");
            _navigationManager.NavigateTo("login");
        }
    }
}
