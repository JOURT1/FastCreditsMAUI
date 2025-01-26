using JhoelSuarezPruebaProg2.Interfaces;
using JhoelSuarezPruebaProg2.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace JhoelSuarezPruebaProg2.Repositories
{
    public class JsuarezLegalRepository : IJSLegalRepo
    {
        private readonly SQLiteConnection _database;

        public JsuarezLegalRepository(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<JSuarezLegal>();
        }

        public bool CrearLegal(JSuarezLegal legal)
        {
            try
            {
                int result = _database.Insert(legal);
                Debug.WriteLine($"CrearLegal: Insert result = {result}");
                return result > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"CrearLegal: Exception = {ex.Message}");
                return false;
            }
        }

        public bool ActualizarLegal(JSuarezLegal legal)
        {
            try
            {
                int result = _database.Update(legal);
                Debug.WriteLine($"ActualizarLegal: Update result = {result}");
                return result > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ActualizarLegal: Exception = {ex.Message}");
                return false;
            }
        }

        public bool EliminarLegal(string Denuncias)
        {
            try
            {
                var legal = _database.Table<JSuarezLegal>().FirstOrDefault(l => l.Denuncias == Denuncias);
                if (legal != null)
                {
                    int result = _database.Delete(legal);
                    Debug.WriteLine($"EliminarLegal: Delete result = {result}");
                    return result > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EliminarLegal: Exception = {ex.Message}");
                return false;
            }
        }

        public IEnumerable<JSuarezLegal> DevulveListadoLegal()
        {
            try
            {
                var legales = _database.Table<JSuarezLegal>().ToList();
                Debug.WriteLine($"DevulveListadoLegal: Count = {legales.Count}");
                return legales;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DevulveListadoLegal: Exception = {ex.Message}");
                return Enumerable.Empty<JSuarezLegal>();
            }
        }

        public JSuarezLegal DevulveInfoLegal(string cedula)
        {
            try
            {
                var legal = _database.Table<JSuarezLegal>().FirstOrDefault(l => l.Cedula == cedula);
                Debug.WriteLine($"DevulveInfoLegal: Legal = {legal?.Denuncias}");
                return legal;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DevulveInfoLegal: Exception = {ex.Message}");
                return null;
            }
        }

        public IEnumerable<JSuarezLegal> DevulveLegalesPorCedula(string cedula)
        {
            try
            {
                var legales = _database.Table<JSuarezLegal>().Where(l => l.Cedula == cedula).ToList();
                Debug.WriteLine($"DevulveLegalesPorCedula: Count = {legales.Count}");
                return legales;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DevulveLegalesPorCedula: Exception = {ex.Message}");
                return Enumerable.Empty<JSuarezLegal>();
            }
        }
    }
}

