using System.ComponentModel.DataAnnotations.Schema;

public class Computadora
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; private set; }
    public string Marca { get; private set; } = "";
    public string Modelo { get; private set; } = "";
    public bool Disponible { get; private set; }

    private Computadora() { }
    public Computadora(int id, string marca, string modelo)
    {
        Id = id;
        Marca = marca;
        Modelo = modelo;
        Disponible = true;
    }
    public bool Reservar()
    {
        if (!Disponible)
        {
            return false;
        }

        Disponible = false;
        return true;
    }
    public void Liberar()
    {
        Disponible = true;
    }
    public void Mostrar()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Marca: {Marca}");
        Console.WriteLine($"Modelo: {Modelo}");
        Console.WriteLine($"Estado: {(Disponible ? "Disponible" : "Reservada")}");
    }
}
