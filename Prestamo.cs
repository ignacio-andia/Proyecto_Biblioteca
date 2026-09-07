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
    );
}
