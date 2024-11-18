using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Security.Rental.Domain.Entities;

namespace Security.Rental.Infrastructure.Persistence
{
    public class RentalConfiguration : IEntityTypeConfiguration<BikeRental>
    {
        public void Configure(EntityTypeBuilder<BikeRental> builder)
        {
            builder.ToTable("rentals");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                .ValueGeneratedOnAdd();

            builder.Property(r => r.BikeType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(r => r.PickupDateTime)
                .IsRequired();

            builder.Property(r => r.DropoffDateTime)
                .IsRequired();

            builder.Property(r => r.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(r => r.Status)
                .IsRequired();

            builder.Property(r => r.CreatedAt)
                .IsRequired();

            builder.Property(r => r.UpdatedAt)
                .IsRequired();
        }
    }
}