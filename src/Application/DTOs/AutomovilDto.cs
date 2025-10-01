namespace Application.DTOs
{
    public class AutomovilDto
    {
        public int Id { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public int? Fabricacion { get; set; }
        public string? NumeroMotor { get; set; }
        public string? NumeroChasis { get; set; }
    }
}
