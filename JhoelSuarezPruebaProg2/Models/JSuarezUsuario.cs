using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace JhoelSuarezPruebaProg2.Models
{
    public class JSuarezUsuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Edad { get; set; }
        public string Fecha_Nacimiento { get; set; }
        public string Genero { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
}
