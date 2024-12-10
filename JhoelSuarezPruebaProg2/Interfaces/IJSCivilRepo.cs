using JhoelSuarezPruebaProg2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JhoelSuarezPruebaProg2.Interfaces
{
    public interface IJSCivilRepo
    {
        bool CrearCivil(JSuarezCivil civil);
        bool ActualizarCivil(JSuarezCivil civil);
        bool EliminarCivil(string Casado);
        IEnumerable<JSuarezCivil> DevulveListadoCivil(); //o List al inicio para que sea lista
        //Ienumerable es para una lista mas compleja
        JSuarezCivil DevulveInfoCivil(string Casado);
    }
}
