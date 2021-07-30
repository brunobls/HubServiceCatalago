using Hub.Service.Catalago.Application.Commands;
using Hub.Service.Catalago.Application.Queries;
using Hub.Service.Catalago.Domain;
using Hub.Service.Catalago.Infra.Data.EF.Context;
using Hub.Service.Catalago.Infra.Data.Repository;
using Hub.Service.Core.Communication.Mediator;
using Hub.Service.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hub.Service.Catalago.Api
{
    public static class Setup
    {
        public static void ConfigureEntityFrameworkCore(this IServiceCollection services, IConfiguration Configuration) {
            var conn = Configuration.GetConnectionString("HubMysql");

            //services.AddDbContext<FornecedorContext>(o => o.UseLazyLoadingProxies()
            //    .UseMySql(conn, ServerVersion.AutoDetect(conn)));

            services.AddDbContext<FornecedorContext>(o => o.UseMySql(conn, ServerVersion.AutoDetect(conn)));
        }

        public static void ConfigureServices(this IServiceCollection services) {
            // Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
          
            // Handler
            services.AddScoped<IRequestHandler<AdicionarFornecedorCommand, bool>, FornecedorCommandHandler>();

            // Queries
            services.AddScoped<IFornecedorQueries, FornecedorQueries>();

            // Repository
            services.AddScoped<IFornecedorRepository, FornecedorRepositorySqlEf>();

            // Context
            services.AddScoped<FornecedorContext>();
        }
    }
}
