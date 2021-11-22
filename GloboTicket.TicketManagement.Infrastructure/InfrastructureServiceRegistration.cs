using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Models.Mail;
using GloboTicket.TicketManagement.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GloboTicket.TicketManagement.Infrastructure
{
   public static class InfrastructureServiceRegistration
   {
      public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
      {
         services.Configure<EmailSettings>(config.GetSection("EmailSettings"));
         services.AddTransient<IEmailService, EmailService>();
         return services;
      }
   }
}
