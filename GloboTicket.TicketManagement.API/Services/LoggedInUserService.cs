using System.Security.Claims;
using GloboTicket.TicketManagement.Application.Contracts;

namespace GloboTicket.TicketManagement.API.Services
{
   public class LoggedInUserService : ILoggedInUserService
   {
      public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
      {
         UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
      }

      public string UserId { get; }
   }
}