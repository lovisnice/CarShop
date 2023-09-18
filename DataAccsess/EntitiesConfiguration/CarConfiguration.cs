using CarShop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace CarShop.EntitiesConfiguration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(c => c.Manufacturer)
            .HasMaxLength(50);

            builder.Property(c => c.Year)
                .IsRequired()
                .HasDefaultValue(DateTime.Now.Year)
                ;
   
            builder.Property(c => c.Color)
                .IsRequired()
                .HasMaxLength(20)
                ;

        }
    }
}
