using JhoelSuarezPruebaProg2.Interfaces;
using JhoelSuarezPruebaProg2.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace JhoelSuarezPruebaProg2.Repositories
{
    public class JsuarezCarroRepository : IJSCarroRepo
    {
        private readonly SQLiteConnection _database;

        public JsuarezCarroRepository(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<JSuarezCarro>();
        }

        public bool CrearCarro(JSuarezCarro carro)
        {
            try
            {
                int result = _database.Insert(carro);
                Debug.WriteLine($"CrearCarro: Insert result = {result}");
                return result > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"CrearCarro: Exception = {ex.Message}");
                return false;
            }
        }

        public bool ActualizarCarro(JSuarezCarro carro)
        {
            try
            {
                int result = _database.Update(carro);
                Debug.WriteLine($"ActualizarCarro: Update result = {result}");
                return result > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ActualizarCarro: Exception = {ex.Message}");
                return false;
            }
        }

        public bool EliminarCarro(string Marca)
        {
            try
            {
                var carro = _database.Table<JSuarezCarro>().FirstOrDefault(c => c.Marca == Marca);
                if (carro != null)
                {
                    int result = _database.Delete(carro);
                    Debug.WriteLine($"EliminarCarro: Delete result = {result}");
                    return result > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EliminarCarro: Exception = {ex.Message}");
                return false;
            }
        }

        public IEnumerable<JSuarezCarro> DevulveListadoCarro()
        {
            try
            {
                var carros = _database.Table<JSuarezCarro>().ToList();
                Debug.WriteLine($"DevulveListadoCarro: Count = {carros.Count}");
                return carros;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DevulveListadoCarro: Exception = {ex.Message}");
                return Enumerable.Empty<JSuarezCarro>();
            }
        }

        public JSuarezCarro DevulveInfoCarro(string Marca)
        {
            try
            {
                var carro = _database.Table<JSuarezCarro>().FirstOrDefault(c => c.Marca == Marca);
                Debug.WriteLine($"DevulveInfoCarro: Carro = {carro?.Marca}");
                return carro;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DevulveInfoCarro: Exception = {ex.Message}");
                return null;
            }
        }

        public IEnumerable<JSuarezCarro> DevulveCarrosPorCedula(string cedula)
        {
            try
            {
                var carros = _database.Table<JSuarezCarro>().Where(c => c.Cedula == cedula).ToList();
                Debug.WriteLine($"DevulveCarrosPorCedula: Count = {carros.Count}");
                return carros;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DevulveCarrosPorCedula: Exception = {ex.Message}");
                return Enumerable.Empty<JSuarezCarro>();
            }
        }
    }
}

