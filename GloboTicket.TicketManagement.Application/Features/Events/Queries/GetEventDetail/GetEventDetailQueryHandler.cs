using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Features.Events
{
   public class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, EventDetailVm>
   {
      private readonly IAsyncRepository<Event> eventRepo;
      private readonly IAsyncRepository<Category> categoryRepo;
      private readonly IMapper mapper;

      public GetEventDetailQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepo, IAsyncRepository<Category> categoryRepo)
      {
         this.eventRepo = eventRepo;
         this.categoryRepo = categoryRepo;
         this.mapper = mapper;
      }

      public async Task<EventDetailVm> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
      {
         var @event = await eventRepo.GetByIdAsync(request.Id);
         var eventDetailDto = mapper.Map<EventDetailVm>(@event);

         var category = await categoryRepo.GetByIdAsync(@event.CategoryId);
         eventDetailDto.Category = mapper.Map<CategoryDto>(category);

         return eventDetailDto;
      }
   }
}
