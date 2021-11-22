using GloboTicket.TicketManagement.Application.Contracts;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{
   public class EventRepository : BaseRepository<Event>, IEventRepository
   {
      public EventRepository(GloboTicketDbContext context)
         : base(context)
      {
      }

      public Task<bool> IsEventNameAndDateUnique(string eventName, DateTime date)
      {
         var matches = context.Events.Any(r => r.Name == eventName && r.Date.Date == date);
         return Task.FromResult(matches);
      }
   }
}