using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TALLER_PROGRAMACION3;

namespace Presentacion
{
    public class Program
    {
        static void Main(string[] args)
        {

            // en esta parte Se crea un objeto de la clase VistaReserva,
            // y es el encargado de mostrar el menú de opciones en la consola.
            new VistaReserva().Menu();
            
        }
    }
}
