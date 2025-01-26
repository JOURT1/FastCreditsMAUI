using System.Collections.Generic;

namespace JhoelSuarezPruebaProg2.Models
{
    public class JSuarezDatosCombinados
    {
        public JSuarezUsuario Usuario { get; set; }
        public List<JSuarezCarro> Carros { get; set; } // Nueva propiedad para la lista de carros
        public List<JSuarezCivil> Civiles { get; set; } // Nueva propiedad para la lista de civiles
        public List<JSuarezLegal> Legales { get; set; } // Nueva propiedad para la lista de legales
    }
}


