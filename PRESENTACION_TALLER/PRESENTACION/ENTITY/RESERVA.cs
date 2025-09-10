using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public  class RESERVA
    {
        //aqui basicamente se declaran las variables con sus respectivos geters and seters
        public int IdReserva { get; set; }
        public string Solicitante { get; set; }
        public int numerodesala { get; set; }  
        public string FechaReserva { get; set; }

    }
}
