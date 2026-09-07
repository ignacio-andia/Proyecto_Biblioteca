using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoBiblioteca
{
    internal record Prestamo(
    int Usuario_ID,
    int Libro_codigo,
    DateTime Fecha_Prestamo,
    DateTime? Fecha_Devolucion
)
    {
        public void MostrarPrestamo()
        {
            Console.WriteLine($"Usuario ID: {Usuario_ID}");
            Console.WriteLine($"Libro Código: {Libro_codigo}");
            Console.WriteLine($"Fecha de Préstamo: {Fecha_Prestamo}");

            if (Fecha_Devolucion.HasValue)
            {
                Console.WriteLine($"Fecha de Devolución: {Fecha_Devolucion.Value}");
            }
            else
            {
                Console.WriteLine("Fecha de Devolución: No devuelto");
            }

            Console.WriteLine("------------------------------");
        }
    }

}
