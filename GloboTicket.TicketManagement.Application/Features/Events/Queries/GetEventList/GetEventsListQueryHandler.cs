using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Features.Events
{
   public class GetEventsListQueryHandler : IRequestHandler<GetEventsListQuery, List<EventListVm>>
   {
      private readonly IMapper mapper;
      private readonly IAsyncRepository<Event> eventRepo;

      public GetEventsListQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepo)
      {
         this.mapper = mapper;
         this.eventRepo = eventRepo;
      }

      public async Task<List<EventListVm>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
      {
         var allEvents = (await eventRepo.ListAllAsync()).OrderBy(r => r.Date);
         return mapper.Map<List<EventListVm>>(allEvents);
      }
   }
}
