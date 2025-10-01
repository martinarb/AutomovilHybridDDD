using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Automovil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fabricacion = table.Column<int>(type: "int", nullable: true),
                    NumeroMotor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroChasis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automovil", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Automovil",
                columns: new[] { "Id", "Color", "Fabricacion", "Marca", "Modelo", "NumeroChasis", "NumeroMotor" },
                values: new object[,]
                {
                    { 1, "Negro", 2020, "Toyota", "Yaris", "CHASIS12345", "MOTOR12345" },
                    { 2, "Rojo", 2019, "Ford", "Mustang", "CHASIS67890", "MOTOR67890" },
                    { 3, "Negro", 2021, "Chevrolet", "Cruze", "CHASIS11223", "MOTOR11223" },
                    { 4, "Gris", 2022, "Honda", "Civic", "CHASIS44556", "MOTOR44556" },
                    { 5, "Azul", 2018, "Volkswagen", "Golf", "CHASIS77889", "MOTOR77889" },
                    { 6, "Blanco", 2023, "Nissan", "Sentra", "CHASIS99001", "MOTOR99001" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Automovil");
        }
    }
}
