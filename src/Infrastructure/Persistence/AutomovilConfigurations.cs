using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Persistence.Configurations
{
    public class AutomovilConfiguration : IEntityTypeConfiguration<Automovil>
    {
        public void Configure(EntityTypeBuilder<Automovil> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.Marca)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Modelo)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Color)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(a => a.NumeroMotor).IsUnique();
            builder.HasIndex(a => a.NumeroChasis).IsUnique();
        }
    }
}