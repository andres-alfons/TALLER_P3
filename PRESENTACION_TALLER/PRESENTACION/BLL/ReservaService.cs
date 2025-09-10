using BAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ReservaService : ENTITY.IReservaRepository<RESERVA>
    {
        List<RESERVA> Reservas;
        ReservaRepository reservaRepository;




        //Inicializa el repositorio y carga todas las reservas almacenadas
        public ReservaService()
        {
            reservaRepository = new ReservaRepository();
            Reservas = reservaRepository.ObtenerTodas();
        }
        public string Agregar(RESERVA reserva)
        {
       
            var mensaje = reservaRepository.Agregar(reserva);

            // Se actualiza la lista local de reservas después de guardar en el repositorio.
            Reservas = reservaRepository.ObtenerTodas();
            return mensaje;

        }


        //Devuelve todas las reservas almacenadas en el sistema.
        public List<RESERVA> ObtenerTodas()
        {
            return Reservas;
        }
    }
}
