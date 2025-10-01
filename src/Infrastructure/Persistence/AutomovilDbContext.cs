using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Persistence.Seeds;
using Infrastructure.Persistence.Configurations;

namespace Infrastructure.Persistence
{
    public class AutomovilDbContext : DbContext
    {
        public AutomovilDbContext(DbContextOptions<AutomovilDbContext> options)
            : base(options)
        {
        }

        public DbSet<Automovil> Automoviles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplica todas las configuraciones (Fluent API)
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(AutomovilDbContext).Assembly);

            // Configuración de la tabla Automovil
            modelBuilder.Entity<Automovil>(entity =>
            {
                entity.ToTable("Automovil");
                entity.HasKey(x => x.Id);

                // Permite autoincremento para nuevos registros
                entity.Property(x => x.Id);
            });

            // Aplica el seed con Ids manuales
            modelBuilder.ApplyConfiguration(new AutomovilSeed());
        }
    }
}