using ProyectoBiblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

class Program
{
    static void menu()
    {
        Console.WriteLine("===================================");
        Console.WriteLine("|    Bienvenido a la Biblioteca   |");
        Console.WriteLine("===================================");
        Console.WriteLine("|1. Registrar libro   *            |");
        Console.WriteLine("|2. Registrar usuario  *           |");
        Console.WriteLine("|3. Registrar préstamo            |");
        Console.WriteLine("|4. Devolver préstamo             |");
        Console.WriteLine("|5. Mostrar libros     *           |");
        Console.WriteLine("|6. Mostrar usuarios    *          |");
        Console.WriteLine("|7. Mostrar préstamos              |");
        Console.WriteLine("|8. Salir                         |");
        Console.WriteLine("===================================");
        Console.WriteLine("|Seleccione una opción:");
    }

    static void menuLibros()
    {
        Console.WriteLine("===================================");
        Console.WriteLine("|         Mostrar Libros          |");
        Console.WriteLine("===================================");
        Console.WriteLine("|1. Todos Los Libros              |");
        Console.WriteLine("|2. Libros Disponibles            |");
        Console.WriteLine("|3. Libros No Disponibles         |");
        Console.WriteLine("===================================");
        Console.WriteLine("|Seleccione una opción:");
    }


    static void MenuPrestamos()
    {
        Console.WriteLine("===================================");
        Console.WriteLine("|         Mostrar Préstamos       |");
        Console.WriteLine("===================================");
        Console.WriteLine("|1. Todos Los Préstamos           |");
        Console.WriteLine("|2. Préstamos Activos             |");
        Console.WriteLine("|3. Préstamos Devueltos           |");
        Console.WriteLine("===================================");
        Console.WriteLine("|Seleccione una opción:");
    }


    static void RegistrarLibro(BibliotecaService service)
    {
        Console.WriteLine("Registrar libro");

        Console.WriteLine("Ingrese el título del libro:");
        string titulo = Console.ReadLine();

        Console.WriteLine("Ingrese el autor del libro:");
        string autor = Console.ReadLine();

        Console.WriteLine("Ingrese el género del libro:");
        string genero = Console.ReadLine();

        Console.WriteLine("Ingrese el código del libro:");
        if (int.TryParse(Console.ReadLine(), out int codigo))
        {
            try
            {
                service.registrarLibro(new Libro(titulo, autor, genero, codigo));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            Console.WriteLine(" ");
            Console.WriteLine("El código debe ser un número - vualva ingresar datos");
            Console.ReadKey();
        }
    }


    static void registrarUsuarios(BibliotecaService service)
    {
        Console.WriteLine("Registrar usuario");

        Console.WriteLine("Ingrese el ID del usuario:");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Ingrese el nombre del usuario:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el correo del usuario:");
            string correo = Console.ReadLine();

            try
            {
                service.registrarUsuario(new Usuario(id, nombre, correo));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        else
        {
            Console.WriteLine("El ID debe ser un número.");
            Console.ReadKey();
        }
    }

    static void registrarPrestamo(BibliotecaService service)
    {
        Console.WriteLine("Registrar préstamo");
        Console.WriteLine("Ingrese el ID del usuario:");
        if (int.TryParse(Console.ReadLine(), out int usuarioId))
        {
            Console.WriteLine("Ingrese el código del libro:");
            if (int.TryParse(Console.ReadLine(), out int libroCodigo))
            {
                bool resultado = service.registraPrestamo(usuarioId, libroCodigo);
                if (resultado)
                {
                    Console.WriteLine(
                        $"Préstamo registrado para el usuario {usuarioId} y el libro {libroCodigo}."
                    );
                }
            }
            else
            {
                Console.WriteLine("El código del libro debe ser un número.");
            }
        }
        else
        {
            Console.WriteLine("El ID del usuario debe ser un número.");
        }
    }

    static void DevolverPrestamo(BibliotecaService service)
    {
        Console.WriteLine("Devolver préstamo");
        Console.WriteLine("Ingrese el ID del usuario:");
        if (int.TryParse(Console.ReadLine(), out int usuarioId))
        {
            Console.WriteLine("Ingrese el código del libro:");
            if (int.TryParse(Console.ReadLine(), out int libroCodigo))
            {
                bool resultado = service.DevolverPrestamo(usuarioId, libroCodigo);
                if (resultado)
                {
                    Console.WriteLine(
                        $"Préstamo devuelto para el usuario {usuarioId} y el libro {libroCodigo}."
                    );
                }
            }
            else
            {
                Console.WriteLine("El código del libro debe ser un número.");
            }
        }
        else
        {
            Console.WriteLine("El ID del usuario debe ser un número.");
        }
    }

    static void Main()
    {

        int opcion;
        int opcion1;
        int opcion2;

        BibliotecaService service = new BibliotecaService();

        //-------- prueba de datos para mostrar libros en el menu
        service.registrarLibro(new Libro("Cien anios de soledad", "Gabriel García Márquez", "Ficción", 12345));
        service.registrarLibro(new Libro("1984", "George Orwell", "Distopía", 98765));
        service.registrarLibro(new Libro("El gran Gatsby", "F. Scott Fitzgerald", "Novela", 54321));

        //-------- prueba de datos para mostrar usuarios en el menu
        service.registrarUsuario(new Usuario(1, "Juan Pérez", "juan.perez@example.com"));
        service.registrarUsuario(new Usuario(2, "María García", "maria.garcia@example.com"));
        service.registrarUsuario(new Usuario(3, "Carlos López", "carlos.lopez@example.com"));

        //-------- prueba de datos para registrar prestamos en el menu
        service.registraPrestamo(1, 12345); // Juan Pérez toma prestado "Cien años de soledad"

        //prueba para devolver un libro prestado
        //service.DevolverPrestamo(1, 12345); // Juan Pérez devuelve "Cien años de soledad"

        do
        {
            Console.Clear();
            menu();

            if (int.TryParse(Console.ReadLine(), out opcion)) //control de errores para que no se rompa el programa si el usuario ingresa un valor no numérico
            {
                switch (opcion)
                {
                case 1:
                    Console.WriteLine(" ");
                        RegistrarLibro(service);
                    break;

                case 2:
                    Console.WriteLine(" ");
                    registrarUsuarios(service);
                    break;

                case 3:
                    registrarPrestamo(service);
                    break;

                case 4:
                    DevolverPrestamo(service);
                    break;

                case 5:
                    Console.Clear();
                    menuLibros();
                        if (int.TryParse(Console.ReadLine(), out opcion1)) //control de errores
                        {
                            switch (opcion1)
                            {
                            case 1:
                                service.MostrarLibros(service.ObtenerLibros());
                                break;
                            case 2:
                                service.MostrarLibros(service.ObtenerLibrosDisponibles());
                                break;
                            case 3:
                                service.MostrarLibros(service.ObternerLibrosNoDisponibles());
                                break;
                            default:
                                Console.WriteLine("Opción no válida");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Debe ingresar un número.");
                        }
                    break;

                case 6:
                    Console.Clear();
                    service.mostrarUsuarios();
                    break;

                case 7:
                    Console.Clear();
                    MenuPrestamos();
                        if (int.TryParse(Console.ReadLine(), out opcion2))
                        {

                            switch (opcion2)
                            {
                                case 1:
                                    service.MostrarPrestamos(service.obtenerTodosLosprestamosRegistrados());
                                    break;

                                case 2:
                                    service.MostrarPrestamos(service.obtenerPrestamosActivos());
                                    break;

                                case 3:
                                    service.MostrarPrestamos(service.obtenerPrestamosDevueltos());
                                    break;
                                default:
                                    Console.WriteLine("Opción no válida");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Debe ingresar un número.");
                        }

                    break;

                case 8:
                    Console.Clear();
                    Console.WriteLine("Saliendo...");
                    Console.WriteLine("presione una vez mas para salir");
                    Console.ReadKey();
                    break;

                default:
                    Console.WriteLine("Opción no válida");
                 
                    break;
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Debe ingresar un número.");
                Console.ReadKey(); // bloque por un rato

            }
        } while(opcion != 8);
    }
}
