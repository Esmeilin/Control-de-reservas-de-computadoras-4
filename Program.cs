
using Microsoft.EntityFrameworkCore;

using ReservasContext db = new ReservasContext();

db.Database.EnsureCreated();

int select = 0;

while (select != 7)
{
    try
    {
        Console.WriteLine("\nCONTROL DE RESERVAS DE COMPUTADORAS");

        Console.WriteLine("1. Registrar computadora");
        Console.WriteLine("2. Registrar usuario");
        Console.WriteLine("3. Reservar computadora");
        Console.WriteLine("4. Consultar disponibilidad");
        Console.WriteLine("5. Cancelar reserva");
        Console.WriteLine("6. Mostrar reservas");
        Console.WriteLine("7. Salir");

        Console.WriteLine("\nSelecciona una opción:");
        select = int.Parse(Console.ReadLine());

        switch (select)
        {
            case 1:
                {
                    Console.WriteLine("\nIngrese el ID de la computadora:");
                    int idComputadora = int.Parse(Console.ReadLine());

                    if (db.Computadoras.Any(c => c.Id == idComputadora))
                    {
                        Console.WriteLine("Error: Esta computadora ya existe");
                    }
                    else
                    {
                        Console.WriteLine("Ingrese la marca:");
                        string marca = Console.ReadLine();

                        Console.WriteLine("Ingrese el modelo:");
                        string modelo = Console.ReadLine();

                        db.Computadoras.Add(new Computadora(idComputadora, marca, modelo));
                        db.SaveChanges();

                        Console.WriteLine("Computadora registrada correctamente");
                    }

                    break;
                }

            case 2:
                {
                    Console.WriteLine("\nIngrese el ID del usuario:");
                    int idUsuario = int.Parse(Console.ReadLine());

                    if (db.Usuarios.Any(u => u.Id == idUsuario))
                    {
                        Console.WriteLine("Error: Este usuario ya existe");
                    }
                    else
                    {
                        Console.WriteLine("Ingrese el nombre:");
                        string nombre = Console.ReadLine();

                        Console.WriteLine("Ingrese el correo:");
                        string correo = Console.ReadLine();

                        db.Usuarios.Add(new Usuario(idUsuario, nombre, correo));
                        db.SaveChanges();

                        Console.WriteLine("Usuario registrado correctamente");
                    }

                    break;
                }

            case 3:
                {
                    Console.WriteLine("\nIngrese el ID del usuario:");
                    int usuarioReserva = int.Parse(Console.ReadLine());

                    Console.WriteLine("Ingrese el ID de la computadora:");
                    int computadoraReserva = int.Parse(Console.ReadLine());

                    Usuario usuario = db.Usuarios.Find(usuarioReserva);
                    Computadora computadora = db.Computadoras.Find(computadoraReserva);

                    if (usuario != null && computadora != null)
                    {
                        if (computadora.Reservar())
                        {
                            Reserva reserva = new Reserva(usuario, computadora);
                            db.Reservas.Add(reserva);

                            db.SaveChanges();

                            Console.WriteLine("Reserva realizada correctamente");
                            Console.WriteLine($"Número de reserva: {reserva.Id}");
                        }
                        else
                        {
                            Console.WriteLine("Error: La computadora no está disponible");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: El usuario o la computadora no existen");
                    }

                    break;
                }

            case 4:
                {
                    var lista = db.Computadoras.ToList();

                    if (lista.Count > 0)
                    {
                        Console.WriteLine("\nCOMPUTADORAS REGISTRADAS");

                        foreach (Computadora c in lista)
                        {
                            c.Mostrar();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No hay computadoras registradas");
                    }

                    break;
                }

            case 5:
                {
                    Console.WriteLine("Ingrese el número de reserva:");
                    int reservaCancelar = int.Parse(Console.ReadLine());

                    Reserva encontrada = db.Reservas
                        .Include(r => r.Computadora)
                        .FirstOrDefault(r => r.Id == reservaCancelar);

                    if (encontrada != null)
                    {
                        encontrada.Computadora.Liberar();
                        db.Reservas.Remove(encontrada);
                        db.SaveChanges();

                        Console.WriteLine("Reserva cancelada correctamente");
                    }
                    else
                    {
                        Console.WriteLine("Error: La reserva no existe");
                    }

                    break;
                }

            case 6:
                {
                    var lista = db.Reservas
                        .Include(r => r.Usuario)
                        .Include(r => r.Computadora)
                        .ToList();

                    if (lista.Count > 0)
                    {
                        Console.WriteLine("\nRESERVAS REGISTRADAS");

                        foreach (Reserva r in lista)
                        {
                            r.Mostrar();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No hay reservas registradas");
                    }

                    break;
                }

            case 7:
                {
                    Console.WriteLine("Cerrando el sistema...");
                    break;
                }

            default:
                {
                    Console.WriteLine("Error: Opción no válida");
                    break;
                }
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Error: Debes ingresar un dato válido");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error inesperado: {ex.Message}");
    }
}