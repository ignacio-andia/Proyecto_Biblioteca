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

        public List<Libro> ObtenerLibros()
        {
            return libros.ToList();
        }

        public List<Libro> ObternerLibrosNoDisponibles()
        {
            return libros.Where(libro => !libro.Disponible).ToList(); 
        }

        public List<Libro> ObtenerLibrosDisponibles()
        {
            return libros.Where(libro => libro.Disponible).ToList();
        }


        public void MostrarLibros(List<Libro> ListaAMostar)
        {
            if (ListaAMostar.Count != 0)
            {
                int i = 0;
               foreach (var libro in ListaAMostar)
                {
                    Console.WriteLine($"Libro {i + 1}:");
                    libro.MostrarLibro();
                    i++;
                    Console.WriteLine("--------------------");
                }
            }
            else
            {
                Console.WriteLine("No hay libros para mostrar.");
            }
        }
    }
}
