using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent
{
   public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
   {
      private readonly IAsyncRepository<Event> eventRepo;
      private readonly IMapper mapper;

      public UpdateEventCommandHandler(IAsyncRepository<Event> eventRepo, IMapper mapper)
      {
         this.eventRepo = eventRepo;
         this.mapper = mapper;
      }

      public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
      {
         var eventToUpdate = await eventRepo.GetByIdAsync(request.EventId);

         mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));

         await eventRepo.UpdateAsync(eventToUpdate);

         return Unit.Value;
      }
   }
}