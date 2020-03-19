using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication;

namespace Ekobiashara.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //services.AddIdentityServer();
            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultScheme = "Cookies";
            //    options.DefaultChallengeScheme = "oidc";
            //})
            //.AddCookie("Cookies")
            //.AddOpenIdConnect("oidc", options =>
            //{
            //    options.SignInScheme = "Cookies";
            //    options.Authority = "https://ekobiasharaid.azurewebsites.net";
            //    options.RequireHttpsMetadata = false;
            //    options.ClientId = "EkobiasharaApp";
            //    options.ClientSecret = "EkobiasharaApp";
            //    options.ResponseType = "code id_token";
            //    options.SaveTokens = true;
            //    options.GetClaimsFromUserInfoEndpoint = true;
            //    options.SignedOutRedirectUri = "https://ekobiashara.azurewebsites.net";
            //    options.Scope.Add("roles");
            //    options.Scope.Add("profile");
            //    //options.Scope.Add("custom.profile");
            //    options.Scope.Add("offline_access");
            //    options.ClaimActions.MapJsonKey("website", "website");
            //    options.ClaimActions.MapJsonKey("role", "role", "role");
            //    options.ClaimActions.MapJsonKey("DisplayName", "DisplayName");
            //    options.TokenValidationParameters.NameClaimType = "DisplayName";
            //    options.TokenValidationParameters.RoleClaimType = "role";
            //});
            //services.AddApplicationInsightsTelemetry();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}")
               /* .RequireAuthorization()*/;
            });
        }
    }
}
