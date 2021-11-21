namespace GloboTicket.TicketManagement.Application.Exceptions
{
   public class BadRequestException : ApplicationException
   {
      public BadRequestException(string msg)
         : base(msg)
      {

      }
   }
}