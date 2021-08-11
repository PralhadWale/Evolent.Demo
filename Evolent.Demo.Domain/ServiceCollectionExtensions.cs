using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Evolent.Demo.Domain.Services;
using Evolent.Demo.Domain.Services.Master;
using Evolent.Demo.Data;
using Evolent.Demo.Domain.Constants;

namespace Evolent.Demo.Domain
{
    /// <summary>
    /// For Dependency Injection
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureDEMODomainServices(this IServiceCollection services)
        {
            //Regiser Data Layer Dependancy
            services.CongfigureDEMODataServices(ApplicationSettings.DefaultDBConnectionString);

            //Register Domain Dependancy
            services.AddScoped<IContactMasterService, ContactMasterService>();
        }

      
    }
}
