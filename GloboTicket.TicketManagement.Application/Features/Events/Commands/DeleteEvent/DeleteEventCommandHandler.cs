using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.DeleteEvent
{
   public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
   {
      private readonly IAsyncRepository<Event> eventRepo;
      private readonly IMapper mapper;

      public DeleteEventCommandHandler(IAsyncRepository<Event> eventRepo, IMapper mapper)
      {
         this.eventRepo = eventRepo;
         this.mapper = mapper;
      }

      public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
      {
         var eventToDelete = await eventRepo.GetByIdAsync(request.EventId);

         await eventRepo.DeleteAsync(eventToDelete);

         return Unit.Value;
      }
   }
}