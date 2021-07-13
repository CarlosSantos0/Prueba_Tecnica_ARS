using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_ARS.Models
{
    public class Plan
    {
        public int Id { get; set; }
        public string Nombre_Plan { get; set; }
        public decimal Monto_Cobertura { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public string Estatus { get; set; }

    }
}
