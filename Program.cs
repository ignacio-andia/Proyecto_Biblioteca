using ProyectoBiblioteca;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        BibliotecaService service = new BibliotecaService();
        service.registrarLibro(new Libro("Cien anios de soledad", "Gabriel García Márquez", "Ficción", 12345));
        service.registrarLibro(new Libro("1984", "George Orwell", "Distopía", 98765));
        service.MostrarLibros();
    }
}
