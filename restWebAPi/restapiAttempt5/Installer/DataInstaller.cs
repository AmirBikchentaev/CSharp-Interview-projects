using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using restapiAttempt5.Data;
using restapiAttempt5.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restapiAttempt5.Installer
{
    public class DataInstaller : Iinstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(
            Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DataContext>();


            services.AddScoped<IPostService, PostService>();

        }
    }
}
