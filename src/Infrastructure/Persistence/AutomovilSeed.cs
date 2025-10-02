using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Persistence.Seeds
{
    public class AutomovilSeed : IEntityTypeConfiguration<Automovil>
    {
        public void Configure(EntityTypeBuilder<Automovil> builder)
        {
            // Usamos objetos anónimos con Id manual
            builder.HasData(
                new { Id = 1,  Marca = "Toyota", Modelo = "Yaris", Color = "Negro", Fabricacion = 2020, NumeroMotor = "MOTOR12345", NumeroChasis = "CHASIS12345" },
                new { Id = 2,  Marca = "Ford", Modelo = "Mustang", Color = "Rojo", Fabricacion = 2019, NumeroMotor = "MOTOR67890", NumeroChasis = "CHASIS67890" },
                new { Id = 3,  Marca = "Chevrolet", Modelo = "Cruze", Color = "Negro", Fabricacion = 2021, NumeroMotor = "MOTOR11223", NumeroChasis = "CHASIS11223" },
                new { Id = 4,  Marca = "Honda", Modelo = "Civic", Color = "Gris", Fabricacion = 2022, NumeroMotor = "MOTOR44556", NumeroChasis = "CHASIS44556" },
                new { Id = 5,  Marca = "Volkswagen", Modelo = "Golf", Color = "Azul", Fabricacion = 2018, NumeroMotor = "MOTOR77889", NumeroChasis = "CHASIS77889" },
                new { Id = 6,  Marca = "Nissan", Modelo = "Sentra", Color = "Blanco", Fabricacion = 2023, NumeroMotor = "MOTOR99001", NumeroChasis = "CHASIS99001" },
                new { Id = 7,  Marca = "Ford", Modelo = "Bronco", Color = "naranja", Fabricacion = 2025, NumeroMotor = "MOTORV877889", NumeroChasis = "CHASISV877889" },
                new { Id = 8,  Marca = "Volkswagen", Modelo = "UP", Color = "blanco", Fabricacion = 2014, NumeroMotor = "MOTOR10123", NumeroChasis = "CHASIS10123" },
                new { Id = 9,  Marca = "Suzuki", Modelo = "Jimny", Color = "Azul", Fabricacion = 2022, NumeroMotor = "MOTOR77811", NumeroChasis = "CHASIS77811" },
                new { Id = 10, Marca = "Volkswagen", Modelo = "Escarabajo", Color = "Rojo", Fabricacion = 1968, NumeroMotor = "MOTOR10000", NumeroChasis = "CHASIS10000" }
            );
        }
    }
}

    
