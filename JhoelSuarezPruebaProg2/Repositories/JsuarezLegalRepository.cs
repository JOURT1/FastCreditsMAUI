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
    public class JsuarezLegalRepository : IJSLegalRepo
    {
        public string _fileName = Path.Combine(FileSystem.AppDataDirectory, "JhoelSuarezlegal.txt");
        //IMPORTANTE: Vamos a Nugget y descargamos NewtonSoftJson
        public bool ActualizarLegal(JSuarezLegal legal)
        {
            throw new NotImplementedException();
        }

        public bool CrearLegal(JSuarezLegal legal)
        {
            try
            {
                string json_data = JsonConvert.SerializeObject(legal);
                File.WriteAllText(_fileName, json_data);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JSuarezLegal DevulveInfoLegal(string Denuncias)
        {
            JSuarezLegal jSuarezLegal = new JSuarezLegal();
            try
            {
                //File.AppendAllText para que no sobre escriba y siga escribiendo
                if (File.Exists(_fileName))
                {
                    string json_data = File.ReadAllText(_fileName);
                    jSuarezLegal = JsonConvert.DeserializeObject<JSuarezLegal>(json_data);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return jSuarezLegal;
        }
        public IEnumerable<JSuarezLegal> DevulveListadoLegal()
        {
            throw new NotImplementedException();
        }

        public bool EliminarLegal(string Denuncias)
        {
            throw new NotImplementedException();
        }
    }
}
