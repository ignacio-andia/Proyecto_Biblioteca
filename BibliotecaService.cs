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
            if(!libros.Any(l => l.Codigo == libro.Codigo))
            {
                libros.Add(libro);
            }
            else
            {
                throw new Exception("El libro con este código ya existe.");
            }
        }


        public void registrarUsuario(Usuario usuario)
        {
            if(!usuarios.Any(u => u.ID == usuario.ID))
            {
                usuarios.Add(usuario);
            }
            else
            {
                throw new Exception("El usuario con este ID ya existe.");
            }
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

        public List<Libro> ObtenerLibrosOrdenadosPorTitulo()
        {
            return libros
                .OrderBy(l => l.Titulo)
                .ToList();
        }

        public List<Libro> ObtenerLibrosPorAutor(string autor)
        {
            return libros
                .Where(l => l.Autor == autor)
                .ToList();
        }

        public List<Libro> ObtenerLibrosPorCategoria(string categoria)
        {
            return libros
                .Where(l => l.Categoria == categoria)
                .ToList();
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
                Console.WriteLine("Libro no exsite.");
                return false;
            }

            if (!libro.Disponible)
            {
                Console.WriteLine("El libro no esta disponible.");
                return false;
            }

            Prestamo nuevoPrestamo = new Prestamo(
                usuario.ID,
                libro.Codigo,
                DateTime.Now,
                null
            );

            libro.Prestar();
            prestamos.Add(nuevoPrestamo);
            return true;
        }

        public bool DevolverPrestamo(int ID_usuario, int Codigo_Libro)
        {
            Prestamo prestamo = prestamos.FirstOrDefault(p => 
                p.Usuario_ID == ID_usuario &&
                p.Libro_codigo == Codigo_Libro &&
                p.Fecha_Devolucion == null
            );
            if (prestamo == null)
            {
                Console.WriteLine("No se encontro un prestamo activo para este usuario y libro.");
                return false;
            }
            Libro libro = BuscarLibro(Codigo_Libro);

            if (libro != null)
            {
                libro.Devolver();
            }

            Prestamo prestamoDevuelto = prestamo with
            {
                Fecha_Devolucion = DateTime.Now
            };

            int indice = prestamos.IndexOf(prestamo);
            prestamos[indice] = prestamoDevuelto;

            return true;

        }

        public List<Prestamo> obtenerPrestamosActivos()
        {
            return prestamos.Where(p => p.Fecha_Devolucion == null).ToList();
        }

        public List<Prestamo> obtenerPrestamosDevueltos()
        {
            return prestamos.Where(p => p.Fecha_Devolucion != null).ToList();
        }

        public List<Prestamo> obtenerTodosLosprestamosRegistrados()
        {
            return prestamos.ToList();
        }

        public void MostrarPrestamos(List<Prestamo> ListaAMostrar)
        {
            if (ListaAMostrar.Count != 0)
            {
                int i = 0;
                foreach (var prestamo in ListaAMostrar)
                {
                    Console.WriteLine($"Prestamo {i + 1}:");
                    prestamo.MostrarPrestamo();
                    i++;
                    Console.WriteLine("--------------------");
                }
            }
            else
            {
                Console.WriteLine("No hay prestamos para mostrar.");
            }
        }


        public bool EliminarLibro(int codigo)
        {
            Libro libro = BuscarLibro(codigo);

            if (libro == null)
            {
                Console.WriteLine("No se encontro un libro con ese codigo.");
                return false;
            }

            if (!libro.Disponible)
            {
                Console.WriteLine("No se puede eliminar el libro porque esta actualmente prestado.");
                return false;
            }

            libros.Remove(libro);
            return true;
        }


        public void MostrarDatosPrincipalesPrestamosActivos()
        {
            var prestamosActivos = prestamos
                .Where(p => p.Fecha_Devolucion == null)
                .Select(p => new
                {
                    Usuario = p.Usuario_ID,
                    Libro = p.Libro_codigo,
                    FechaPrestamo = p.Fecha_Prestamo
                });

            foreach (var prestamo in prestamosActivos)
            {
                Console.WriteLine($"Usuario: {prestamo.Usuario}");
                Console.WriteLine($"Libro: {prestamo.Libro}");
                Console.WriteLine($"Fecha de préstamo: {prestamo.FechaPrestamo}");
                Console.WriteLine("--------------------");
            }
        }


    }
}
