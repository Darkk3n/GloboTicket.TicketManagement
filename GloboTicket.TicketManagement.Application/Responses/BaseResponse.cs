namespace GloboTicket.TicketManagement.Application.Responses
{
   public class BaseResponse
   {
      public BaseResponse()
      {
         Success = true;
      }

      public BaseResponse(string message = null)
      {
         Success = true;
         Message = message;
      }

      public BaseResponse(string message, bool succes)
      {
         Success = succes;
         Message = message;
      }

      public bool Success { get; set; }
      public string Message { get; set; }
      public List<string> Errors { get; set; }
   }
}