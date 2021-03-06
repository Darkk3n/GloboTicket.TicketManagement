using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Contracts
{
   public interface ICategoryRepository : IAsyncRepository<Category>
   {
      Task<List<Category>> GetCategoriesWithEvents(bool includeHistory);
   }
}