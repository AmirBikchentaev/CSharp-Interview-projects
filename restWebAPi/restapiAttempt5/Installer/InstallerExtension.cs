using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restapiAttempt5.Installer
{
    public static class InstallerExtension
    {
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration) 
        {
            var Installers = typeof(Startup).Assembly.ExportedTypes.Where(x =>
            typeof(Iinstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<Iinstaller>().ToList();
            Installers.ForEach(Installers => Installers.InstallServices(services, configuration));

        }
    }
}
