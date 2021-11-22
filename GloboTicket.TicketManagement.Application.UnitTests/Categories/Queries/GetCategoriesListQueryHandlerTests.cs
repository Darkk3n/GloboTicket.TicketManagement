using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Profiles;
using GloboTicket.TicketManagement.Application.UnitTests.Mocks;
using GloboTicket.TicketManagement.Domain.Entities;
using Shouldly;
using Xunit;

namespace GloboTicket.TicketManagement.Application.UnitTests
{
   public class GetCategoriesListQueryHandlerTests
   {
      private readonly IMapper mapper;
      private readonly Mock<IAsyncRepository<Category>> mockCategoryRepo;

      public GetCategoriesListQueryHandlerTests()
      {
         mockCategoryRepo = RepositoryMocks.GetCategoryRepository();
         var configProvider = new MapperConfiguration(cfg =>
         {
            cfg.AddProfile<MappingProfile>();
         });

         mapper = configProvider.CreateMapper();
      }

      [Fact]
      public async Task GetCategoriesListTest()
      {
         var handler = new GetCategoriesListQueryHandler(mapper,mockCategoryRepo.Object);
         var result = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);
         result.ShouldBeOfType<List<CategoryListVm>>();
         result.Count.ShouldBe(4);
      }
   }
}
