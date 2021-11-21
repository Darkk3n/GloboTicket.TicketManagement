using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
   public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
   {
      private readonly IEventRepository eventRepo;
      private readonly IMapper mapper;

      public CreateEventCommandHandler(IEventRepository eventRepo, IMapper mapper)
      {
         this.eventRepo = eventRepo;
         this.mapper = mapper;
      }

      public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
      {
         var @event = mapper.Map<Event>(request);
         @event = await eventRepo.AddAsync(@event);

         return @event.EventId;
      }
   }
}