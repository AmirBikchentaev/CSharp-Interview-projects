using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using restapiAttempt5.Data;
using restapiAttempt5.Installer;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restapiAttempt5
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

            services.InstallServicesInAssembly(Configuration);


        /*    //dat abase integration
               services.AddDbContext<DataContext>(options =>
                   options.UseSqlServer(
                       Configuration.GetConnectionString("DefaultConnection")));
            //identity integration
               services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                   .AddEntityFrameworkStores<DataContext>();
            //swagger integration

               services.AddSwaggerGen(x =>
               {
               x.SwaggerDoc("v1", new OpenApiInfo
               {
                   Title = "DBExample",
                   Version = "V1",
               });
               });*/
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
                app.UseHsts();
            }

            var swaggerOptions = new options.SwaggerOptions();

            Configuration.GetSection(nameof(options.SwaggerOptions)).Bind(swaggerOptions);
            app.UseSwagger(option =>
            {
                option.RouteTemplate = swaggerOptions.JsonRoute;
            });

            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
