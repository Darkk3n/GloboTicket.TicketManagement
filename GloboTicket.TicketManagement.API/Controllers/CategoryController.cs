using GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.TicketManagement.API.Controllers
{
   [Route("api/[Controller]")]
   [ApiController]
   public class CategoryController : Controller
   {
      private readonly IMediator mediator;

      public CategoryController(IMediator mediator)
      {
         this.mediator = mediator;
      }

      [HttpGet("All", Name = "GetAllCategories")]
      [ProducesResponseType(StatusCodes.Status200OK)]
      public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
      {
         var dtos = await mediator.Send(new GetCategoriesListQuery());
         return Ok(dtos);
      }

      [HttpGet("AllWithEvents", Name = "GetCategoriesWithEvents")]
      [ProducesDefaultResponseType]
      [ProducesResponseType(StatusCodes.Status200OK)]
      public async Task<ActionResult<List<CategoryEventListVm>>> GetCategoriesWithEvents(bool includeHistory)
      {
         var dtos = await mediator.Send(new GetCategoriesListWithEventsQuery());
         return Ok(dtos);
      }

      [HttpPost(Name ="AddCategory")]
      public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand createCategoryCommand)
      {
         var response = await mediator.Send(createCategoryCommand);
         return Ok(response);
      }
   }
}
