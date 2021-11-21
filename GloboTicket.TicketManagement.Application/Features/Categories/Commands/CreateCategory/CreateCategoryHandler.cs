using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory
{
   public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
   {
      private readonly IAsyncRepository<Category> categoryRepo;
      private readonly IMapper mapper;

      public CreateCategoryHandler(IAsyncRepository<Category> categoryRepo, IMapper mapper)
      {
         this.categoryRepo = categoryRepo;
         this.mapper = mapper;
      }

      public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
      {
         var response = new CreateCategoryCommandResponse();

         var validator = new CreateCategoryCommandValidator();
         var result = await validator.ValidateAsync(request);

         if (result.Errors.Any())
         {
            response.Success = false;
            response.Errors = new List<string>();
            foreach (var error in result.Errors)
            {
               response.Errors.Add(error.ErrorMessage);
            }
         }
         if (response.Success)
         {
            var category = new Category() { Name = request.Name };
            category = await categoryRepo.AddAsync(category);
            response.Category = mapper.Map<CreateCategoryDto>(category);
         }
         return response;
      }
   }
}