using GloboTicket.TicketManagement.Application.Contracts;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{
   public class OrderRepository : BaseRepository<Order>, IOrderRepository
   {
      public OrderRepository(GloboTicketDbContext context)
         : base(context)
      {
      }

      public async Task<List<Order>> GetPagedOrdersForMonth(DateTime date, int page, int size)
      {
         return await context.Orders
            .Where(r => r.OrderPlaced.Month == date.Month && r.OrderPlaced.Year == date.Year)
            .Skip((page - 1) * size)
            .Take(size)
            .AsNoTracking()
            .ToListAsync();
      }

      public async Task<int> GetTotalCountOfOrdersForMonth(DateTime date)
      {
         return await context.Orders.CountAsync(r => r.OrderPlaced.Month == date.Month && r.OrderPlaced.Year == date.Year);
      }
   }
}