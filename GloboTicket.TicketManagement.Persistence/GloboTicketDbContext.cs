namespace GloboTicket.TicketManagement.Persistence
{
   public class GloboTicketDbContext : DbContext
   {
      public GloboTicketDbContext(DbContextOptions<GloboTicketDbContext> options)
           : base(options)
      {
      }

      public DbSet<Event> Events { get; set; }
      public DbSet<Category> Categories { get; set; }
      public DbSet<Order> Orders { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfigurationsFromAssembly(typeof(GloboTicketDbContext).Assembly);

         //seed data, added through migrations
         var concertGuid = Guid.Parse("b0788d2f-8003-43c1-92a4-edc76a7c5dde");
         var musicalGuid = Guid.Parse("6313179f-7837-473a-a4d5-a5571b43e6a6");
         var playGuid = Guid.Parse("bf3f3002-7e53-441e-8b76-f6280be284aa");
         var conferenceGuid = Guid.Parse("fe98f549-e790-4e9f-aa16-18c2292a2ee9");

         modelBuilder.Entity<Category>().HasData(new Category
         {
            CategoryId = concertGuid,
            Name = "Concerts"
         });
         modelBuilder.Entity<Category>().HasData(new Category
         {
            CategoryId = musicalGuid,
            Name = "Musicals"
         });
         modelBuilder.Entity<Category>().HasData(new Category
         {
            CategoryId = playGuid,
            Name = "Plays"
         });
         modelBuilder.Entity<Category>().HasData(new Category
         {
            CategoryId = conferenceGuid,
            Name = "Conferences"
         });

         modelBuilder.Entity<Event>().HasData(new Event
         {
            EventId = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}"),
            Name = "John Egbert Live",
            Price = 65,
            Artist = "John Egbert",
            Date = DateTime.Now.AddMonths(6),
            Description = "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.",
            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg",
            CategoryId = concertGuid
         });

         modelBuilder.Entity<Event>().HasData(new Event
         {
            EventId = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
            Name = "The State of Affairs: Michael Live!",
            Price = 85,
            Artist = "Michael Johnson",
            Date = DateTime.Now.AddMonths(9),
            Description = "Michael Johnson doesn't need an introduction. His 25 concert across the globe last year were seen by thousands. Can we add you to the list?",
            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/michael.jpg",
            CategoryId = concertGuid
         });

         modelBuilder.Entity<Event>().HasData(new Event
         {
            EventId = Guid.Parse("{B419A7CA-3321-4F38-BE8E-4D7B6A529319}"),
            Name = "Clash of the DJs",
            Price = 85,
            Artist = "DJ 'The Mike'",
            Date = DateTime.Now.AddMonths(4),
            Description = "DJs from all over the world will compete in this epic battle for eternal fame.",
            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/dj.jpg",
            CategoryId = concertGuid
         });

         modelBuilder.Entity<Event>().HasData(new Event
         {
            EventId = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
            Name = "Spanish guitar hits with Manuel",
            Price = 25,
            Artist = "Manuel Santinonisi",
            Date = DateTime.Now.AddMonths(4),
            Description = "Get on the hype of Spanish Guitar concerts with Manuel.",
            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/guitar.jpg",
            CategoryId = concertGuid
         });

         modelBuilder.Entity<Event>().HasData(new Event
         {
            EventId = Guid.Parse("{1BABD057-E980-4CB3-9CD2-7FDD9E525668}"),
            Name = "Techorama 2021",
            Price = 400,
            Artist = "Many",
            Date = DateTime.Now.AddMonths(10),
            Description = "The best tech conference in the world",
            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/conf.jpg",
            CategoryId = conferenceGuid
         });

         modelBuilder.Entity<Event>().HasData(new Event
         {
            EventId = Guid.Parse("{ADC42C09-08C1-4D2C-9F96-2D15BB1AF299}"),
            Name = "To the Moon and Back",
            Price = 135,
            Artist = "Nick Sailor",
            Date = DateTime.Now.AddMonths(8),
            Description = "The critics are over the moon and so will you after you've watched this sing and dance extravaganza written by Nick Sailor, the man from 'My dad and sister'.",
            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/musical.jpg",
            CategoryId = musicalGuid
         });

         modelBuilder.Entity<Order>().HasData(new Order
         {
            Id = Guid.Parse("{7E94BC5B-71A5-4C8C-BC3B-71BB7976237E}"),
            OrderTotal = 400,
            OrderPaid = true,
            OrderPlaced = DateTime.Now,
            UserId = Guid.Parse("{A441EB40-9636-4EE6-BE49-A66C5EC1330B}")
         });

         modelBuilder.Entity<Order>().HasData(new Order
         {
            Id = Guid.Parse("{86D3A045-B42D-4854-8150-D6A374948B6E}"),
            OrderTotal = 135,
            OrderPaid = true,
            OrderPlaced = DateTime.Now,
            UserId = Guid.Parse("{AC3CFAF5-34FD-4E4D-BC04-AD1083DDC340}")
         });

         modelBuilder.Entity<Order>().HasData(new Order
         {
            Id = Guid.Parse("{771CCA4B-066C-4AC7-B3DF-4D12837FE7E0}"),
            OrderTotal = 85,
            OrderPaid = true,
            OrderPlaced = DateTime.Now,
            UserId = Guid.Parse("{D97A15FC-0D32-41C6-9DDF-62F0735C4C1C}")
         });

         modelBuilder.Entity<Order>().HasData(new Order
         {
            Id = Guid.Parse("{3DCB3EA0-80B1-4781-B5C0-4D85C41E55A6}"),
            OrderTotal = 245,
            OrderPaid = true,
            OrderPlaced = DateTime.Now,
            UserId = Guid.Parse("{4AD901BE-F447-46DD-BCF7-DBE401AFA203}")
         });

         modelBuilder.Entity<Order>().HasData(new Order
         {
            Id = Guid.Parse("{E6A2679C-79A3-4EF1-A478-6F4C91B405B6}"),
            OrderTotal = 142,
            OrderPaid = true,
            OrderPlaced = DateTime.Now,
            UserId = Guid.Parse("{7AEB2C01-FE8E-4B84-A5BA-330BDF950F5C}")
         });

         modelBuilder.Entity<Order>().HasData(new Order
         {
            Id = Guid.Parse("{F5A6A3A0-4227-4973-ABB5-A63FBE725923}"),
            OrderTotal = 40,
            OrderPaid = true,
            OrderPlaced = DateTime.Now,
            UserId = Guid.Parse("{F5A6A3A0-4227-4973-ABB5-A63FBE725923}")
         });

         modelBuilder.Entity<Order>().HasData(new Order
         {
            Id = Guid.Parse("{BA0EB0EF-B69B-46FD-B8E2-41B4178AE7CB}"),
            OrderTotal = 116,
            OrderPaid = true,
            OrderPlaced = DateTime.Now,
            UserId = Guid.Parse("{7AEB2C01-FE8E-4B84-A5BA-330BDF950F5C}")
         });
      }

      public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
      {
         foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
         {
            switch (entry.State)
            {
               case EntityState.Added:
                  entry.Entity.CreatedDate = DateTime.Now;
                  break;
               case EntityState.Modified:
                  entry.Entity.LastModifiedDate = DateTime.Now;
                  break;
            }
         }
         return base.SaveChangesAsync(cancellationToken);
      }
   }
}