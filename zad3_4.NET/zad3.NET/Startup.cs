using Amazon.Auth.AccessControlPolicy;
using Amazon.Runtime.Internal.Util;
using Consul;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nest;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Twilio.Jwt.Taskrouter;
using zad3.NET.Data;
using zad3.NET.Models;

namespace zad3.NET
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
            services.AddDbContext<List>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("ListaFizzbuzz"));
            });


            services.AddRazorPages();

  


            // services.AddMemoryCache();// proces naszej aplikacji u¿ywamy aby przechowywaæ ma³e informacje
            services.AddDistributedMemoryCache();


            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(600); //czas podawany w sekundach
             //   options.Cookie.HttpOnly = true; //Wskazuje, czy plik cookie jest dostêpny przez skrypt po stronie klienta.
             //   options.Cookie.IsEssential = true; //Wskazuje, czy ten plik cookie jest istotny, aby aplikacja dzia³a³a poprawnie. W przypadku wartoœci true sprawdzane s¹ sprawdzanie zasad zgody. Wartoœæ domyœlna to false.
            });//domyœlnie 20 minut

            services.AddScoped<IAuthorizationHandler,
                          ContactIsOwnerAuthorizationHandler>();
            services.AddAuthorization(options =>
            {

                options.AddPolicy("user",
                    policy => policy.RequireClaim(ClaimTypes.Name, "a"));

            });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();  // przed UseEndpoints po UseRouting

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
            
        }
    }
}
