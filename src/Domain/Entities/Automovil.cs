namespace Domain.Entities;

public class Automovil
{
    public int Id { get; private set; }
    public string Marca { get; private set; }
    public string Modelo { get; private set; }
    public string Color { get; private set; }
    public int? Fabricacion { get; private set; }
    public string? NumeroMotor { get; private set; }
    public string? NumeroChasis { get; private set; }

    // Constructor protegido para EF Core
    protected Automovil() { }

    // Constructor de dominio
    public Automovil(string marca, string modelo, string color, int? fabricacion, string? numeroMotor, string? numeroChasis)
    {
        Marca = marca ?? throw new ArgumentNullException(nameof(marca));
        Modelo = modelo ?? throw new ArgumentNullException(nameof(modelo));
        Color = color ?? throw new ArgumentNullException(nameof(color));
        Fabricacion = fabricacion;
        NumeroMotor = numeroMotor;
        NumeroChasis = numeroChasis;
    }

    // Método de dominio para actualizar el automóvil
    public void Actualizar(string marca, string modelo, string color, int? fabricacion, string? numeroMotor, string? numeroChasis)
    {
        Marca = marca ?? throw new ArgumentNullException(nameof(marca));
        Modelo = modelo ?? throw new ArgumentNullException(nameof(modelo));
        Color = color ?? throw new ArgumentNullException(nameof(color));
        Fabricacion = fabricacion;
        NumeroMotor = numeroMotor;
        NumeroChasis = numeroChasis;
    }
}