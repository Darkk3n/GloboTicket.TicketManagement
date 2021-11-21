using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList
{
   public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, List<CategoryListVm>>
   {
      private readonly IAsyncRepository<Category> categoryRepo;
      private readonly IMapper mapper;

      public GetCategoriesListQueryHandler(IMapper mapper, IAsyncRepository<Category> categoryRepo)
      {
         this.mapper = mapper;
         this.categoryRepo = categoryRepo;
      }

      public async Task<List<CategoryListVm>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
      {
         var allCategories = (await categoryRepo.ListAllAsync()).OrderBy(r => r.Name);
         return mapper.Map<List<CategoryListVm>>(allCategories);
      }
   }
}
