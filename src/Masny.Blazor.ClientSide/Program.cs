using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Masny.Blazor.ClientSide.Interfaces;
using Masny.Blazor.ClientSide.Services;
using Masny.Blazor.ClientSide.Helpers;

namespace Masny.Blazor.ClientSide
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped<IMessageService, MessageService>();
            builder.Services.AddScoped<IHttpService, HttpService>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddScoped(x => {
                var apiUrl = new Uri(builder.HostEnvironment.BaseAddress);

                return builder.Configuration["fakeBackend"] == "true"
                    ? new HttpClient(new FakeBackendHandler()) { BaseAddress = apiUrl }
                    : new HttpClient() { BaseAddress = apiUrl };
            });

            var host = builder.Build();

            var authenticationService = host.Services.GetRequiredService<IAuthenticationService>();
            await authenticationService.Initialize();

            await host.RunAsync();
        }
    }
}
