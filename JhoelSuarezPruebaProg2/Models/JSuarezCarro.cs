using SQLite;

namespace JhoelSuarezPruebaProg2.Models
{
    public class JSuarezCarro
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Año { get; set; }
        public string Precio { get; set; }
        public string Cedula { get; set; } // Nueva propiedad para vincular con el usuario
    }
}

