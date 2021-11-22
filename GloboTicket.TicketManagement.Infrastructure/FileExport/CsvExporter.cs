using System.Globalization;
using CsvHelper;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;

namespace GloboTicket.TicketManagement.Infrastructure.FileExport
{
   public class CsvExporter : ICsvExport
   {
      public byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos)
      {
         using (var stream = new MemoryStream())
         {
            using (var streamWriter = new StreamWriter(stream))
            {
               using (var csvWriter = new CsvWriter(streamWriter, new CultureInfo("en-US")))
               {
                  csvWriter.WriteRecords(eventExportDtos);
               }
            }
            return stream.ToArray();
         }
      }
   }
}