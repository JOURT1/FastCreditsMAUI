using JhoelSuarezPruebaProg2.Interfaces;
using JhoelSuarezPruebaProg2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JhoelSuarezPruebaProg2.Repositories
{
//Referenciar arriba en using y clic derecho sobre IJSuarez y usar interfaz generada por el IDE
    public class JSuarezUsuarioRepository : IJSuarezUsuarioRepository
    {
        //public JSuarezUsuario DevuelveInfoUsuario()
        //{
        //    return new JSuarezUsuario()
        //    {
        //        Telefono = 1,
        //        Nombre = "Hola Mundo"
        //    };
        //}
       //
        public string _fileName = Path.Combine(FileSystem.AppDataDirectory, "JhoelSuarez.txt");
        //IMPORTANTE: Vamos a Nugget y descargamos NewtonSoftJson
        public bool ActualizarUsuario(JSuarezUsuario usuario)
        {
            throw new NotImplementedException();
        }

        public bool CrearUsuario(JSuarezUsuario usuario)
        {
            try
            {
                string json_data = JsonConvert.SerializeObject(usuario);
                File.WriteAllText(_fileName, json_data);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JSuarezUsuario DevulveInfoUsuario(string Telefono)
        {
            JSuarezUsuario jSuarezUsuario = new JSuarezUsuario();
            try
            {
                //File.AppendAllText para que no sobre escriba y siga escribiendo
                if (File.Exists(_fileName))
                {
                    string json_data = File.ReadAllText(_fileName);
                    jSuarezUsuario = JsonConvert.DeserializeObject<JSuarezUsuario>(json_data);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return jSuarezUsuario;
        }

        public IEnumerable<JSuarezUsuario> DevulveListadoUsuarios()
        {
            throw new NotImplementedException();
        }

        public bool EliminarUsuario(string Telefono)
        {
            throw new NotImplementedException();
        }
    }
}
