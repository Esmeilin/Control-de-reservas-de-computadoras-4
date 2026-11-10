public class Reserva
{
    
    public int Id { get; private set; }

    public int UsuarioId { get; private set; }
    public int ComputadoraId { get; private set; }

    public Usuario Usuario { get; private set; } = null!;
    public Computadora Computadora { get; private set; } = null!;

    public DateTime Fecha { get; private set; }

    private Reserva() { }

    public Reserva(Usuario usuario, Computadora computadora)
    {
        Usuario = usuario;
        Computadora = computadora;
        UsuarioId = usuario.Id;
        ComputadoraId = computadora.Id;
        Fecha = DateTime.Now;
    }
    public void Mostrar()
    {
        Console.WriteLine($"Reserva: {Id}");
        Console.WriteLine($"Usuario: {Usuario.Nombre}");
        Console.WriteLine($"Computadora: {Computadora.Marca}");
        Console.WriteLine($"Modelo: {Computadora.Modelo}");
        Console.WriteLine($"Fecha: {Fecha}");
    }
}
