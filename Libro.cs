using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoBiblioteca
{
    internal class Libro : IPrestable
    {
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public string Categoria { get; private set; }
        public int Codigo { get; private set; }
        public bool Disponible { get; private set; }

        public Libro(string Titulo, string Autor, string Categoria, int Codigo)
        {
            this.Titulo = Titulo;
            this.Autor = Autor;
            this.Categoria = Categoria;
            this.Codigo = Codigo;
            this.Disponible = true;
        }

        public void Prestar()
        {
            Disponible = false;
        }

        public void Devolver()
        {
            Disponible = true;
        }
        public void MostrarLibro()
        {
            Console.WriteLine($"Titulo: {Titulo}");
            Console.WriteLine($"Autor: {Autor}");
            Console.WriteLine($"Categoria: {Categoria}");
            Console.WriteLine($"Codigo: {Codigo}");
            if (Disponible) { 
                Console.WriteLine("Disponible: Sí");
            }
            else
            {
                Console.WriteLine("Disponible: No"); 
            }
            Console.WriteLine("---------------------------");
        }




    }
}



