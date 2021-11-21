using GloboTicket.TicketManagement.Application.Contracts;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
   public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
   {
      private readonly IEventRepository eventRepo;

      public CreateEventCommandValidator(IEventRepository eventRepo)
      {
         this.eventRepo = eventRepo;

         RuleFor(r => r.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

         RuleFor(r => r.Date)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(DateTime.Now);

         RuleFor(r => r)
            .MustAsync(EventNameAndDateUnique)
            .WithMessage("An event with the same name and date already exists.");

         RuleFor(r => r.Price)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .GreaterThan(0);
      }

      private async Task<bool> EventNameAndDateUnique(CreateEventCommand e, CancellationToken token)
      {
         return !(await eventRepo.IsEventNameAndDateUnique(e.Name, e.Date));
      }
   }
}