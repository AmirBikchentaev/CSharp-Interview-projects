using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restapiAttempt5.Installer
{
    public class MVCInstaller : Iinstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration conf)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "DBExample",
                    Version = "V1",
                });
            });
        }
    }
}
