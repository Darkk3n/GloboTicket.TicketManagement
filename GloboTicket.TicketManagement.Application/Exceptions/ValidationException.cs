namespace GloboTicket.TicketManagement.Application.Exceptions
{
   public class ValidationException : ApplicationException
   {
      public List<string> Errors { get; set; }

      public ValidationException(ValidationResult validationResult)
      {
         Errors = new List<string>();

         foreach (var error in validationResult.Errors)
         {
            Errors.Add(error.ErrorMessage);
         }
      }
   }
}