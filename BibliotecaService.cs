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


        public void registrarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public void mostrarUsuarios()
        {
            if (usuarios.Count != 0)
            {
                int i = 0;
                foreach (var usuario in usuarios)
                {
                    Console.WriteLine($"Usuario #{i + 1}:");
                    usuario.MostrarUsuario();
                    i++;
                    Console.WriteLine("--------------------");
                }
            }
            else
            {
                Console.WriteLine("No hay usuarios para mostrar.");
            }
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

        public Usuario BuscarUsuario(int ID_usuario)
        {
            return usuarios.FirstOrDefault(usuario => usuario.ID == ID_usuario);
        }

        public Libro BuscarLibro(int Codigo_Libro)
        {
            return libros.FirstOrDefault(libro => libro.Codigo == Codigo_Libro);
        }

        public bool registraPrestamo(int ID_usuario, int Codigo_Libro)
        {
            Usuario usuario = BuscarUsuario(ID_usuario);
            Libro libro = BuscarLibro(Codigo_Libro);

            if (usuario == null)
            {
                Console.WriteLine("Usuario no Existe.");
                return false;
            }

            if (libro == null)
            {
                Console.WriteLine("Libro no Exsite.");
                return false;
            }

            if (!libro.Disponible)
            {
                Console.WriteLine("El libro no está disponible.");
                return false;
            }

            Prestamo nuevoPrestamo = new Prestamo(
                usuario.ID,
                libro.Codigo,
                DateTime.Now,
                null
            );

            libro.Prestar();
            prestamos.Add( nuevoPrestamo );
            return true;
        }

    }
}
