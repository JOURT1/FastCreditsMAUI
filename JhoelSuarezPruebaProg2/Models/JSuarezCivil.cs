using SQLite;

namespace JhoelSuarezPruebaProg2.Models
{
    public class JSuarezCivil
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Casado { get; set; }
        public string Hijos { get; set; }
        public string Cedula { get; set; } 
    }
}
