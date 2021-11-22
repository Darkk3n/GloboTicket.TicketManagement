using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport
{
   public class GetEventsExportQueryHandler : IRequestHandler<GetEventsExportQuery, EventExportFileVm>
   {
      private readonly IAsyncRepository<Event> eventRepo;
      private readonly IMapper mapper;
      private readonly ICsvExport csvExporter;

      public GetEventsExportQueryHandler(IAsyncRepository<Event> eventRepo, IMapper mapper, ICsvExport csvExporter)
      {
         this.eventRepo = eventRepo;
         this.mapper = mapper;
         this.csvExporter = csvExporter;
      }

      public async Task<EventExportFileVm> Handle(GetEventsExportQuery request, CancellationToken cancellationToken)
      {
         var allEvents = mapper.Map<List<EventExportDto>>((await eventRepo.ListAllAsync()).OrderBy(r => r.Date));
         var fileData = csvExporter.ExportEventsToCsv(allEvents);
         var eventExportFileDto = new EventExportFileVm
         {
            ContentType = "text/csv",
            Data = fileData,
            EventExportFileName = $"{Guid.NewGuid()}.csv"
         };
         return eventExportFileDto;
      }
   }
}
