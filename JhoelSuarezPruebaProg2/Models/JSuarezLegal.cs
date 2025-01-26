using SQLite;

namespace JhoelSuarezPruebaProg2.Models
{
    public class JSuarezLegal
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Denuncias { get; set; }
        public string Antecedentes_Penales { get; set; }
        public string Fraudes { get; set; }
        public string Cedula { get; set; } // Nueva propiedad para vincular con el usuario
    }
}

