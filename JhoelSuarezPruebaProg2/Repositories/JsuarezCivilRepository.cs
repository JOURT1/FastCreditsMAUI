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
    public class JsuarezCivilRepository : IJSCivilRepo
    {
        public string _fileName = Path.Combine(FileSystem.AppDataDirectory, "JhoelSuarezcivil.txt");
        //IMPORTANTE: Vamos a Nugget y descargamos NewtonSoftJson
        public bool ActualizarCivil(JSuarezCivil civil)
        {
            throw new NotImplementedException();
        }

        public bool CrearCivil(JSuarezCivil civil)
        {
            try
            {
                string json_data = JsonConvert.SerializeObject(civil);
                File.WriteAllText(_fileName, json_data);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JSuarezCivil DevulveInfoCivil(string Casado)
        {
            JSuarezCivil jSuarezCivil = new JSuarezCivil();
            try
            {
                //File.AppendAllText para que no sobre escriba y siga escribiendo
                if (File.Exists(_fileName))
                {
                    string json_data = File.ReadAllText(_fileName);
                    jSuarezCivil = JsonConvert.DeserializeObject<JSuarezCivil>(json_data);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return jSuarezCivil;
        }
        public IEnumerable<JSuarezCivil> DevulveListadoCivil()
        {
            throw new NotImplementedException();
        }

        public bool EliminarCivil(string Casado)
        {
            throw new NotImplementedException();
        }
    }
}
