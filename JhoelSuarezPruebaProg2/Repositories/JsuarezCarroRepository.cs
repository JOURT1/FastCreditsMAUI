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
    public class JsuarezCarroRepository : IJSCarroRepo
    {
        public string _fileName = Path.Combine(FileSystem.AppDataDirectory, "JhoelSuarezcarro.txt");
        //IMPORTANTE: Vamos a Nugget y descargamos NewtonSoftJson
        public bool ActualizarCarro(JSuarezCarro carro)
        {
            throw new NotImplementedException();
        }

        public bool CrearCarro(JSuarezCarro carro)
        {
            try
            {
                string json_data = JsonConvert.SerializeObject(carro);
                File.WriteAllText(_fileName, json_data);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JSuarezCarro DevulveInfoCarro(string Marca)
        {
            JSuarezCarro jSuarezCarro = new JSuarezCarro();
            try
            {
                //File.AppendAllText para que no sobre escriba y siga escribiendo
                if (File.Exists(_fileName))
                {
                    string json_data = File.ReadAllText(_fileName);
                    jSuarezCarro = JsonConvert.DeserializeObject<JSuarezCarro>(json_data);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return jSuarezCarro;
        }
        public IEnumerable<JSuarezCarro> DevulveListadoCarro()
        {
            throw new NotImplementedException();
        }

        public bool EliminarCarro(string Marca)
        {
            throw new NotImplementedException();
        }
    }
}
