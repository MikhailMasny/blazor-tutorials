using Masny.Blazor.ServerSide.Authorization;
using Masny.Blazor.ServerSide.Data;
using Masny.Blazor.ServerSide.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Masny.Blazor.ServerSide
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite("DataSource=app.db");
            });
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<AppDbContext>();

            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("IsAdmin", policy =>
                {
                    policy.AddRequirements(new EmailRequirement("admin.com"));
                });
            });
            services.AddSingleton<IAuthorizationHandler, EmailAuthorizationHandler>();
            services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();

            services.AddSingleton<WeatherForecastService>();

            //services.AddTransient<RandomService>();
            services.AddScoped<RandomService>();
            //services.AddSingleton<RandomService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
