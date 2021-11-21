using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Contracts
{
   public interface IEventRepository : IAsyncRepository<Event>
   {
      Task<bool> IsEventNameAndDateUnique(string eventName, DateTime date);
   }
}