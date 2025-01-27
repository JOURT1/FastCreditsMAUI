using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
namespace JhoelSuarezPruebaProg2.Models
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public DateTime Fecha_Nacimiento { get; set; } 
        public string Genero { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
}