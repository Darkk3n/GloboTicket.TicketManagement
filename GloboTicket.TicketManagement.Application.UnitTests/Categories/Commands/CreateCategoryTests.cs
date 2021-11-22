using System.Threading;
using System.Threading.Tasks;
using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory;
using GloboTicket.TicketManagement.Application.Profiles;
using GloboTicket.TicketManagement.Application.UnitTests.Mocks;
using GloboTicket.TicketManagement.Domain.Entities;
using Shouldly;
using Xunit;

namespace GloboTicket.TicketManagement.Application.UnitTests.Categories.Commands
{
   public class CreateCategoryTests
   {
      private readonly IMapper mapper;
      private readonly Mock<IAsyncRepository<Category>> mockCategoryRepo;

      public CreateCategoryTests()
      {
         mockCategoryRepo = RepositoryMocks.GetCategoryRepository();
         var configProvider = new MapperConfiguration(cfg =>
         {
            cfg.AddProfile<MappingProfile>();
         });

         mapper = configProvider.CreateMapper();
      }

      [Fact]
      public async Task Handle_ValidCategory_AddedToCategoriesRepo()
      {
         var handler = new CreateCategoryHandler(mockCategoryRepo.Object, mapper);
         var result = await handler.Handle(new CreateCategoryCommand { Name = "Test" }, CancellationToken.None);

         var allCategories = await mockCategoryRepo.Object.ListAllAsync();

         allCategories.Count.ShouldBe(5);
      }
   }
}