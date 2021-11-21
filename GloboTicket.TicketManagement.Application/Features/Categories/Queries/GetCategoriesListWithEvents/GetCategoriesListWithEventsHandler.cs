using GloboTicket.TicketManagement.Application.Contracts;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
   public class GetCategoriesListWithEventsHandler : IRequestHandler<GetCategoriesListWithEventsQuery, List<CategoryEventListVm>>
   {
      private readonly IMapper mapper;
      private readonly ICategoryRepository categoryRepository;

      public GetCategoriesListWithEventsHandler(IMapper mapper, ICategoryRepository categoryRepository)
      {
         this.mapper = mapper;
         this.categoryRepository = categoryRepository;
      }
      public async Task<List<CategoryEventListVm>> Handle(GetCategoriesListWithEventsQuery request, CancellationToken cancellationToken)
      {
         var list = await categoryRepository.GetCategoriesWithEvents(request.IncludeHistory);
         return mapper.Map<List<CategoryEventListVm>>(list);
      }
   }
}
