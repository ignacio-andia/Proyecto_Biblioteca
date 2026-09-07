using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoBiblioteca
{
    internal class Usuario
    {
        public int ID { get; private  set; }
        private string Nombre { get; set; }
        private string Correo { get; set; } 


        public Usuario(int id, string nombre, string correo)
        {
            ID = id;
            Nombre = nombre;
            Correo = correo;
        }

        public void MostrarUsuario()
        {
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Correo: {Correo}");
            Console.WriteLine("---------------------------");
        }
    }
}
