using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GloboTicket.TicketManagement.Application.Contracts;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{
   public class BaseRepository<T> : IAsyncRepository<T> where T : class
   {
      protected readonly GloboTicketDbContext context;

      public BaseRepository(GloboTicketDbContext context)
      {
         this.context = context;
      }

      public async Task<T> AddAsync(T entity)
      {
         await context.Set<T>().AddAsync(entity);
         await context.SaveChangesAsync();
         return entity;
      }

      public async Task DeleteAsync(T entity)
      {
         context.Set<T>().Remove(entity);
         await context.SaveChangesAsync();
      }

      public virtual async Task<T> GetByIdAsync(Guid id) => await context.Set<T>().FindAsync(id);

      public async Task<IReadOnlyList<T>> ListAllAsync() => await context.Set<T>().ToListAsync();

      public async Task UpdateAsync(T entity)
      {
         context.Entry(entity).State = EntityState.Modified;
         await context.SaveChangesAsync();
      }
   }
}