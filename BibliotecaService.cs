using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoBiblioteca
{
    internal class BibliotecaService
    {
        private List<Libro> libros;
        private List<Usuario> usuarios;
        private List<Prestamo> prestamos;

        public BibliotecaService()
        {
            libros = new List<Libro>();
            usuarios = new List<Usuario>();
            prestamos = new List<Prestamo>();
        }

        public void registrarLibro(Libro libro)
        {
            libros.Add(libro);
        }

        public void MostrarLibros()
        {
            int i = 0;
            foreach (var libro in libros)
            {
                Console.WriteLine($"Libro {i + 1}:");
                libro.MostrarLibro();
                i++;
                Console.WriteLine(" ");
            }
        }
    }
}
