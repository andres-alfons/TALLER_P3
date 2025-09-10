using BL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TALLER_PROGRAMACION3
{
    internal class VistaReserva
    {
        ReservaService servicioReserva;
        private int i;
        

        public VistaReserva()
        {
            servicioReserva = new ReservaService();
    
        }
        public void Menu()
        {
            int opcion;

            do
            {

                // Asignar el Id de la próxima reserva según la cantidad ya almacenada.
                i = servicioReserva.ObtenerTodas().Count + 1;
                Console.Clear();
                Console.SetCursorPosition(20, 4); Console.WriteLine("S E R V I C I O  D E  R E S E R V A s");
                Console.SetCursorPosition(20, 6); Console.WriteLine("1. Reservar");
                Console.SetCursorPosition(20, 7); Console.WriteLine("2. Mostrar Reservas");
                Console.SetCursorPosition(20, 8); Console.WriteLine("3. Salir");
                Console.SetCursorPosition(20, 11); Console.WriteLine("Seleccione una opción: ");
                Console.SetCursorPosition(44, 11); opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:

                        // Llamar al método que captura los datos de una nueva reserva.
                        CapturarReserva();
                        break;
                    case 2:

                        // Llamar al método que muestra todas las reservas registradas.
                        MostrarReservas();
                        break;
             

                }

            } while (opcion != 3);
        }
        private void CapturarReserva()
        {
            bool salaDisponible;
            RESERVA reserva = new RESERVA();
            Console.Clear();
            Console.WriteLine("INFORMACION RESSERVA");


            // Mostrar al usuario el Id de la nueva reserva (calculado previamente en el menú)
            Console.WriteLine("Tu id de reserva: " + i);
            reserva.IdReserva = i;
            do
            {
                Console.Write("Nombres: ");
                reserva.Solicitante = Console.ReadLine()?.Trim();

                // Si el campo está vacío, mostrar advertencia y repetir la solicitud.
                if (string.IsNullOrEmpty(reserva.Solicitante))
                {
                    Console.Clear();
                    Console.WriteLine(" El nombre no puede estar vacío. Intenta nuevamente.");
                    
                }
            } while (string.IsNullOrEmpty(reserva.Solicitante));


            // aqui se  Capturar y validar el número de sala 
            do
            {
                Console.WriteLine("Número de la Sala: ");
                string entrada = Console.ReadLine();


                // Validar que no esté vacío.
                if (string.IsNullOrWhiteSpace(entrada))
                {
                    Console.Clear();
                    Console.WriteLine("La sala no puede estar vacía. Intenta nuevamente.");
                    continue;
                }

                reserva.numerodesala = int.Parse(entrada);
                break;
            } while (true);


            Console.WriteLine("Fecha: ");
            reserva.FechaReserva = (Console.ReadLine());

            var mensaje = servicioReserva.Agregar(reserva);
            Console.WriteLine(mensaje);
            Console.ReadKey();
        }
        private void MostrarReservas()
        {
            int salto = 0;// Controla el salto de línea entre cada reserva.

            Console.Clear();
            Console.SetCursorPosition(12, 3); Console.WriteLine("LISTA DE RESERVAS");
            Console.SetCursorPosition(15, 5); Console.Write("-------------------------------------------");
            Console.SetCursorPosition(15, 6); Console.WriteLine("ID_RESERVA");
            Console.SetCursorPosition(28, 6); Console.WriteLine("NOMBRE");
            Console.SetCursorPosition(40, 6); Console.WriteLine("NO. DE SALA");
            Console.SetCursorPosition(55, 6); Console.WriteLine("FECHA-RESERVA");



            var lista = servicioReserva.ObtenerTodas();

            // Si no hay datos que mostrar, mostrar mensaje y salir.
            if (lista == null)
            {
                Console.Clear();
                Console.SetCursorPosition(15, 8 + salto); Console.Write("no hay datos que mostrar");
                Console.ReadKey();
                return;
            }


            // Recorrer cada reserva y mostrarla en una fila.
            foreach (var item in lista)
            {
                Console.SetCursorPosition(15, 8 + salto); Console.Write(item.IdReserva);
                Console.SetCursorPosition(28, 8 + salto); Console.Write(item.Solicitante);
                Console.SetCursorPosition(40, 8 + salto); Console.Write(item.numerodesala);
                Console.SetCursorPosition(55, 8 + salto); Console.Write(item.FechaReserva);
                Console.SetCursorPosition(15, 9 + salto); Console.Write("-------------------------------------------");


                // Aumentar el salto para la siguiente fila.
                salto += 2;
            }

            // Esperar a que el usuario presione una tecla antes de volver al menú.
            Console.ReadKey();

        }
    }
}
