using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShop.Data.Interfaces;
using OnlineShop.Data.mocks;
using OnlineShop.Data.Models;

namespace OnlineShop
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
            services.AddTransient<IAllItems, MockItems>();
            services.AddTransient<IItemsCategory, MockCategory>();
            services.AddRazorPages();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => Cart.GetCart(sp));

            services.AddControllers(options => options.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();
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
                app.UseStaticFiles();
            }

            if (env.IsProduction())
            {
                app.Run(async (HttpContext) =>
                {
                    await HttpContext.Response.WriteAsync("Production");
                });
            }
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default","{controller=Categories}/{action=IndexCategories}/{id?}");
                routes.MapRoute("categoryFilter", "{controller=Items}/{action=IndexItems}/{id?}");
                routes.MapRoute("simpleItem", "{controller=SimpleItem}/{action=IndexSItem}/{id?}");
                //routes.MapRoute(name: "categoryFilter", template: "Items/{action}/{category?}", defaults: new { Controller = "Items", action = "List" });
                //routes.MapRoute("categoryFilter", "{controller=Categories}/{action=List}/{id?}");
            });


                app.UseHttpsRedirection();
     

            app.UseRouting();

            app.UseAuthorization();


        }
    }
}
