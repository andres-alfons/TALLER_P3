using ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class ReservaRepository: ENTITY.RESERVA

    {
        string ruta = "Reserva.txt";
        public string Agregar(RESERVA entity)
        {
            try
            {
                //1
                StreamWriter escritor = new StreamWriter(ruta, true);
                //2
                escritor.WriteLine($"{entity.IdReserva};{entity.Solicitante};{entity.numerodesala};{entity.FechaReserva};");
                //3 Cerrar el flujo de escritura para liberar recursos y asegurar que se guarde la información.
                escritor.Close();

                // Mensaje de confirmación al usuario indicando que la reserva fue guardada correctamente.
                return $"se guardo la reserva a nombre de {entity.Solicitante}";
            }
            catch (Exception ex)
            {
                // Si ocurre un error, se devuelve el mensaje de la excepción.
                return ex.Message;
            }

        }
        public List<RESERVA> ObtenerTodas()
        {
            try
            {
                List<RESERVA> lista = new List<RESERVA>();

                // Abrir el archivo de texto en modo lectura.
                StreamReader lector = new StreamReader(ruta);

                while (!lector.EndOfStream)
                {
                    // Leer cada línea y mapearla a un objeto RESERVA.
                    lista.Add(Mappear(lector.ReadLine()));
                }
                lector.Close();
                return lista;
            }
            catch (Exception)
            {
                // Si ocurre un error (archivo no existe, formato inválido, etc...),
                // se retorna null como indicador de fallo.
                return null;
            }
        }
        private RESERVA Mappear(string linea)
        {
            RESERVA Reserva = new RESERVA();
            //var aux = linea.Split(';');

            // Asignar cada parte a la propiedad correspondiente de la entidad.

            Reserva.IdReserva = int.Parse(linea.Split(';')[0]);
            Reserva.Solicitante = linea.Split(';')[1];
            Reserva.numerodesala = int.Parse(linea.Split(';')[2]);
            Reserva.FechaReserva = linea.Split(';')[3];

            return Reserva;
        }
    }
}
