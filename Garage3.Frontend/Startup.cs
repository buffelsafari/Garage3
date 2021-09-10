using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage3.Data;
using Microsoft.EntityFrameworkCore;
using Garage3.Frontend.FakeServices;
using Garage3.Services;
using Garage3.Frontend.Services.ViewServices;

namespace Garage3.Frontend
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

            services.AddScoped<IViewService, ViewService>();


            services.AddScoped<IGarageService, FakeGarageService>(); // ------------------------fake testobject-------------------------------------------
            services.AddScoped<IVehicleService, FakeVehicleService>(); // ------------------------fake testobject-------------------------------------------
            services.AddScoped<IMemberService, FakeMemberService>(); // ------------------------fake testobject-------------------------------------------
            services.AddScoped<IBookingService, FakeBookingService>(); // ------------------------fake testobject-------------------------------------------

            services.AddDbContext<GarageContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("GarageContext")));
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
