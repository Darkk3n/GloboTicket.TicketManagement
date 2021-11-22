using System;
using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using Xunit;

namespace GloboTicket.TicketManagement.Persistence.IntegrationTests
{
   public class GloboTicketDbContextTests
   {
      private readonly GloboTicketDbContext globoTicketDbContext;
      private readonly Mock<ILoggedInUserService> mockLoggedIn;
      private readonly string loggedInUserId;

      public GloboTicketDbContextTests()
      {
         var options = new DbContextOptionsBuilder<GloboTicketDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
         loggedInUserId = Guid.Empty.ToString();
         mockLoggedIn = new Mock<ILoggedInUserService>();
         mockLoggedIn.Setup(r => r.UserId).Returns(loggedInUserId);

         globoTicketDbContext = new GloboTicketDbContext(options, mockLoggedIn.Object);
      }

      [Fact]
      public async void Save_SetCreateByProperty()
      {
         var ev = new Event
         {
            EventId = Guid.NewGuid(),
            Name = "Test Event",
            Artist = "Test Artist",
            Description = "Test",
            ImageUrl = "Foo",
            LastModifiedBy = "Test"
         };
         globoTicketDbContext.Events.Add(ev);
         await globoTicketDbContext.SaveChangesAsync();

         ev.CreatedBy.ShouldBe(loggedInUserId);
      }
   }
}
