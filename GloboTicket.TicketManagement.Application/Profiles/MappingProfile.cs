using GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using GloboTicket.TicketManagement.Application.Features.Events;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Profiles
{
   public class MappingProfile : Profile
   {
      public MappingProfile()
      {
         CreateMap<Event, EventListVm>().ReverseMap();
         CreateMap<Category, CategoryDto>().ReverseMap();
         CreateMap<Category, CreateCategoryDto>().ReverseMap();        
         CreateMap<Event, EventDetailVm>().ReverseMap();
         CreateMap<Category, CategoryListVm>().ReverseMap();
         CreateMap<Category, CategoryEventListVm>().ReverseMap();
         CreateMap<Event, CreateEventCommand>().ReverseMap();
         CreateMap<Event, UpdateEventCommand>().ReverseMap();
      }
   }
}