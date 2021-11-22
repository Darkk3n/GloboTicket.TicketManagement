using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;

namespace GloboTicket.TicketManagement.Application.Contracts.Infrastructure
{
   public interface ICsvExport
   {
      byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
   }
}