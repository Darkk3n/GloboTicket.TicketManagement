using GloboTicket.TicketManagement.Application.Contracts;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{
   public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
   {
      public CategoryRepository(GloboTicketDbContext context) 
         : base(context)
      {
      }

      public async Task<List<Category>> GetCategoriesWithEvents(bool includeHistory)
      {
         var allCategories = await context.Categories.Include(r => r.Events).ToListAsync();
         if (!includeHistory)
         {
            allCategories.ForEach(r => r.Events.ToList().RemoveAll(r => r.Date < DateTime.Today));
         }
         return allCategories;
      }
   }
}