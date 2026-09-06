using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoBiblioteca
{
    internal record Prestamo
    {
        private int Usuario_ID { get; set; }
        private int libro_codigo { get; set; }
        private DateTime fecha_prestamo { get; set; }
        private DateTime? fecha_devolucion { get; set; }
    }
}
