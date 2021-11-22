using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Models;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
   public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
   {
      private readonly IEventRepository eventRepo;
      private readonly IMapper mapper;
      private readonly IEmailService mailService;

      public CreateEventCommandHandler(IEventRepository eventRepo, IMapper mapper, IEmailService mailService)
      {
         this.eventRepo = eventRepo;
         this.mapper = mapper;
         this.mailService = mailService;
      }

      public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
      {
         var validator = new CreateEventCommandValidator(eventRepo);
         var result = await validator.ValidateAsync(request);
         if (result.Errors.Any())
         {
            throw new Exceptions.ValidationException(result);
         }
         var @event = mapper.Map<Event>(request);
         @event = await eventRepo.AddAsync(@event);

         try
         {
            await mailService.SendEmail(new Email
            {
               To = "gerardo.aguilar01@outlook.com",
               Body = $"A new event was created: {request}",
               Subject = "A new event was created"
            });
         }
         catch (Exception ex)
         {
            //This shouldn't stop the API from doing else so this can be logged.
         }
         return @event.EventId;
      }
   }
}