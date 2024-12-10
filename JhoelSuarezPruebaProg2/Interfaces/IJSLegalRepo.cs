using JhoelSuarezPruebaProg2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JhoelSuarezPruebaProg2.Interfaces
{
    public interface IJSLegalRepo
    {
        bool CrearLegal(JSuarezLegal legal);
        bool ActualizarLegal(JSuarezLegal legal);
        bool EliminarLegal(string Denuncias);
        IEnumerable<JSuarezLegal> DevulveListadoLegal(); //o List al inicio para que sea lista
        //Ienumerable es para una lista mas compleja
        JSuarezLegal DevulveInfoLegal(string Denuncias);
    }
}
