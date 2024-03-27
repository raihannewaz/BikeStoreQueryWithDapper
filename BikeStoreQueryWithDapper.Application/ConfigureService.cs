using BikeStoreQueryWithDapper.Application.CommonCQRS;
using BikeStoreQueryWithDapper.Application.CommonCQRS.Queries;
using BikeStoreQueryWithDapper.Domain.OrderItemEntity;
using BikeStoreQueryWithDapper.Domain.StockEntity;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreQueryWithDapper.Application
{
    public static class ConfigureService
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {

            services.AddMediatR(c =>
            {
                c.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });
            services.AddTransient<IRequestHandler<GetCommonQuery<CommonDTO>,List<CommonDTO>>,GetCommonQueryHandler<CommonDTO>>();
            services.AddTransient<IRequestHandler<GetCommonQuery<Stock>,List<Stock>>,GetCommonQueryHandler<Stock>>();

            return services;
        }
    }
}
