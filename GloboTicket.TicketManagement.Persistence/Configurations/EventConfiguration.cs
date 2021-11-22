using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GloboTicket.TicketManagement.Persistence.Configurations
{
   public class EventConfiguration : IEntityTypeConfiguration<Event>
   {
      public void Configure(EntityTypeBuilder<Event> builder)
      {
         builder.Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(50);
      }
   }
}