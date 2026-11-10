using Microsoft.EntityFrameworkCore;

public class ReservasContext : DbContext
{
    public DbSet<Computadora> Computadoras { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Reserva> Reservas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=localhost\SQLEXPRESS;Database=ReservasComputadoras;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
