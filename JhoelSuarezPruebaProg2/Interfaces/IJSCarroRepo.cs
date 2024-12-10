using JhoelSuarezPruebaProg2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JhoelSuarezPruebaProg2.Interfaces
{
    public interface IJSCarroRepo
    {
        bool CrearCarro(JSuarezCarro carro);
        bool ActualizarCarro(JSuarezCarro carro);
        bool EliminarCarro(string Marca);
        IEnumerable<JSuarezCarro> DevulveListadoCarro(); //o List al inicio para que sea lista
        //Ienumerable es para una lista mas compleja
        JSuarezCarro DevulveInfoCarro(string Marca);
    }
}
