using JhoelSuarezPruebaProg2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JhoelSuarezPruebaProg2.Interfaces
{
    public interface IJSuarezUsuarioRepository
    {
        bool CrearUsuario(JSuarezUsuario usuario);
        bool ActualizarUsuario(JSuarezUsuario usuario);
        bool EliminarUsuario(string Telefono);
        IEnumerable<JSuarezUsuario> DevulveListadoUsuarios(); //o List al inicio para que sea lista
        //Ienumerable es para una lista mas compleja
        JSuarezUsuario DevulveInfoUsuario(string Telefono);

    }
}
