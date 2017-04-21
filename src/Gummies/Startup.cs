using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Gummies.Models;

namespace Gummies
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public IConfigurationRoot Configuration { get; set; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddEntityFramework()
                .AddDbContext<GummiesContext>(options =>
                    options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseStaticFiles();

            var newContext = app.ApplicationServices.GetService<GummiesContext>();
            AddTestData(newContext);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Gummies}/{action=Index}/{id?}");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }

        private static void AddTestData(GummiesContext context)
        {
            var autoGummy1 = new Models.Gummy
            {
                Name = "Pale Ale Pints",
                Cost = "3",
                Country = "Germany",
                Image = "https://www.sugarfina.com/shop/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/P/0/P0132.jpg"
            };

            context.Gummies.Add(autoGummy1);

            var autoGummy2 = new Models.Gummy
            {
                Name = "Parisian Pineapples",
                Cost = "8",
                Country = "France",
                Image = "https://www.sugarfina.com/shop/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/p/a/parisian-pineapples.jpg"
            };

            context.Gummies.Add(autoGummy2);

            var autoGummy3 = new Models.Gummy
            {
                Name = "Ice Cream Cones",
                Cost = "3",
                Country = "Germany",
                Image = "https://www.sugarfina.com/shop/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/P/0/P0099.jpg"
            };

            context.Gummies.Add(autoGummy3);

            var autoGummy4 = new Models.Gummy
            {
                Name = "Roses",
                Cost = "9",
                Country = "Germany",
                Image = "https://www.sugarfina.com/shop/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/b/u/but_first_rose_bowl_72dpi.jpg"
            };

            context.Gummies.Add(autoGummy4);

            var autoGummy5 = new Models.Gummy
            {
                Name = "Beach Buddies",
                Cost = "4",
                Country = "Germany",
                Image = "https://www.sugarfina.com/shop/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/P/0/P0015.jpg"
            };

            context.Gummies.Add(autoGummy5);

            var autoGummy6 = new Models.Gummy
            {
                Name = "Wild Strawberry Fruttini",
                Cost = "9",
                Country = "Italy",
                Image = "https://www.sugarfina.com/shop/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/P/0/P0177.jpg"
            };

            context.Gummies.Add(autoGummy6);

            var autoGummy7 = new Models.Gummy
            {
                Name = "Gummy Kicks",
                Cost = "8",
                Country = "Germany",
                Image = "https://www.sugarfina.com/shop/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/P/0/P0089.jpg"
            };

            context.Gummies.Add(autoGummy7);

            context.SaveChanges();
        }
    }
}
