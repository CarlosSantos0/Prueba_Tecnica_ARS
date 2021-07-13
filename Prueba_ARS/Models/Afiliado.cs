using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_ARS.Models
{
    public class Afiliado
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public char Sexo   { get; set; }
        public string Cedula { get; set; }
        public string Numero_Seguridad_Social { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public decimal Monto_Consumido { get; set; }
        public int Id_Estatus { get; set; }
        public int Id_Plan { get; set; }
    }
}
