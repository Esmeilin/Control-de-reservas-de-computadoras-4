using System.ComponentModel.DataAnnotations.Schema;
public class Usuario
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; private set; }
    public string Nombre { get; private set; } = "";
    public string Correo { get; private set; } = "";

    private Usuario() { }

    public Usuario(int id, string nombre, string correo)
    {
        Id = id;
        Nombre = nombre;
        Correo = correo;
    }
}
