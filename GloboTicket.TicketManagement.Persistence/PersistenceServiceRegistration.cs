using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GloboTicket.TicketManagement.Persistence
{
   public static class PersistenceServiceRegistration
   {
      public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration config)
      {
         services.AddDbContext<GloboTicketDbContext>(opt =>
            opt.UseSqlServer(config.GetConnectionString("GloboTicketConnection")));

         services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

         services.AddScoped<ICategoryRepository, CategoryRepository>();
         services.AddScoped<IEventRepository, EventRepository>();
         services.AddScoped<IOrderRepository, OrderRepository>();
         return services;
      }
   }
}
