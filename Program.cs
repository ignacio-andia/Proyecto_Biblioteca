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
        Console.WriteLine("|2. Registrar usuario             |");
        Console.WriteLine("|3. Registrar préstamo            |");
        Console.WriteLine("|4. Mostrar libros     *           |");
        Console.WriteLine("|5. Mostrar usuarios              |");
        Console.WriteLine("|6. Mostrar préstamos Activos     |");
        Console.WriteLine("|7. Salir                         |");
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
            service.registrarLibro(new Libro(titulo, autor, genero, codigo));
        }
        else
        {
            Console.WriteLine(" ");
            Console.WriteLine("El código debe ser un número - vualva ingresar datos");
            Console.ReadKey();
        }
    }

    static void Main()
    {

        int opcion;
        int opcion1;

        BibliotecaService service = new BibliotecaService();

        //-------- prueba de datos para mostrar libros en el menu
        service.registrarLibro(new Libro("Cien anios de soledad", "Gabriel García Márquez", "Ficción", 12345));
        service.registrarLibro(new Libro("1984", "George Orwell", "Distopía", 98765));
        service.registrarLibro(new Libro("El gran Gatsby", "F. Scott Fitzgerald", "Novela", 54321));

        do
        {
            Console.Clear();
            menu();

            if (int.TryParse(Console.ReadLine(), out opcion)) //control de errores para que no se rompa el programa si el usuario ingresa un valor no numérico
            {
                switch (opcion)
                {
                case 1:
                    RegistrarLibro(service);
                    break;

                case 2:
                    Console.WriteLine("Registrar usuario");
                    break;

                case 3:
                    Console.WriteLine("Registrar préstamo");
                    break;

                case 4:
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

                case 5:
                    Console.WriteLine("Mostrar usuarios");
                    break;

                case 6:
                    Console.WriteLine("Mostrar préstamos");
                    break;

                case 7:
                    Console.Clear();
                    Console.WriteLine("Saliendo...");
                    Console.WriteLine("presione una vez mas para salir");
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
        } while(opcion != 7);
    }
}
