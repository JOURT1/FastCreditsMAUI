using JhoelSuarezPruebaProg2.Interfaces;
using JhoelSuarezPruebaProg2.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace JhoelSuarezPruebaProg2.Repositories
{
    public class JsuarezCivilRepository : IJSCivilRepo
    {
        private readonly SQLiteConnection _database;

        public JsuarezCivilRepository(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<JSuarezCivil>();
        }

        public bool CrearCivil(JSuarezCivil civil)
        {
            try
            {
                int result = _database.Insert(civil);
                Debug.WriteLine($"CrearCivil: Insert result = {result}");
                return result > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"CrearCivil: Exception = {ex.Message}");
                return false;
            }
        }

        public bool ActualizarCivil(JSuarezCivil civil)
        {
            try
            {
                int result = _database.Update(civil);
                Debug.WriteLine($"ActualizarCivil: Update result = {result}");
                return result > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ActualizarCivil: Exception = {ex.Message}");
                return false;
            }
        }

        public bool EliminarCivil(string Casado)
        {
            try
            {
                var civil = _database.Table<JSuarezCivil>().FirstOrDefault(c => c.Casado == Casado);
                if (civil != null)
                {
                    int result = _database.Delete(civil);
                    Debug.WriteLine($"EliminarCivil: Delete result = {result}");
                    return result > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EliminarCivil: Exception = {ex.Message}");
                return false;
            }
        }

        public IEnumerable<JSuarezCivil> DevulveListadoCivil()
        {
            try
            {
                var civiles = _database.Table<JSuarezCivil>().ToList();
                Debug.WriteLine($"DevulveListadoCivil: Count = {civiles.Count}");
                return civiles;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DevulveListadoCivil: Exception = {ex.Message}");
                return Enumerable.Empty<JSuarezCivil>();
            }
        }

        public JSuarezCivil DevulveInfoCivil(string cedula)
        {
            try
            {
                var civil = _database.Table<JSuarezCivil>().FirstOrDefault(c => c.Cedula == cedula);
                Debug.WriteLine($"DevulveInfoCivil: Civil = {civil?.Casado}");
                return civil;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DevulveInfoCivil: Exception = {ex.Message}");
                return null;
            }
        }

        public IEnumerable<JSuarezCivil> DevulveCivilesPorCedula(string cedula)
        {
            try
            {
                var civiles = _database.Table<JSuarezCivil>().Where(c => c.Cedula == cedula).ToList();
                Debug.WriteLine($"DevulveCivilesPorCedula: Count = {civiles.Count}");
                return civiles;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DevulveCivilesPorCedula: Exception = {ex.Message}");
                return Enumerable.Empty<JSuarezCivil>();
            }
        }
    }
}
