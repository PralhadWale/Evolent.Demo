using Evolent.Demo.Data.Core;
using Evolent.Demo.Data.Entity.Master;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evolent.Demo.Data
{
    public static class ServiceCollectionExtension
    {
        public static void CongfigureDEMODataServices(this IServiceCollection services, string defaultDBConnection)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IGenericRepository<ContactMaster>>( s=> new GenericRepository<ContactMaster>(defaultDBConnection));
        }
    }
}
