using JhoelSuarezPruebaProg2.Interfaces;
using JhoelSuarezPruebaProg2.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace JhoelSuarezPruebaProg2.Repositories
{
    public class JSuarezUsuarioRepository : IJSuarezUsuarioRepository
    {
        private readonly SQLiteConnection _database;

        public JSuarezUsuarioRepository(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<JSuarezUsuario>();
        }

        public bool CrearUsuario(JSuarezUsuario usuario)
        {
            try
            {
                int result = _database.Insert(usuario);
                Debug.WriteLine($"CrearUsuario: Insert result = {result}");
                return result > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"CrearUsuario: Exception = {ex.Message}");
                return false;
            }
        }

        public bool ActualizarUsuario(JSuarezUsuario usuario)
        {
            try
            {
                int result = _database.Update(usuario);
                Debug.WriteLine($"ActualizarUsuario: Update result = {result}");
                return result > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ActualizarUsuario: Exception = {ex.Message}");
                return false;
            }
        }

        public bool EliminarUsuario(string Telefono)
        {
            try
            {
                var usuario = _database.Table<JSuarezUsuario>().FirstOrDefault(u => u.Telefono == Telefono);
                if (usuario != null)
                {
                    int result = _database.Delete(usuario);
                    Debug.WriteLine($"EliminarUsuario: Delete result = {result}");
                    return result > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EliminarUsuario: Exception = {ex.Message}");
                return false;
            }
        }

        public IEnumerable<JSuarezUsuario> DevulveListadoUsuarios()
        {
            try
            {
                var usuarios = _database.Table<JSuarezUsuario>().ToList();
                Debug.WriteLine($"DevulveListadoUsuarios: Count = {usuarios.Count}");
                return usuarios;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DevulveListadoUsuarios: Exception = {ex.Message}");
                return Enumerable.Empty<JSuarezUsuario>();
            }
        }

        public JSuarezUsuario DevulveInfoUsuario(string cedula)
        {
            try
            {
                var usuario = _database.Table<JSuarezUsuario>().FirstOrDefault(u => u.Cedula == cedula);
                Debug.WriteLine($"DevulveInfoUsuario: Usuario = {usuario?.Nombre}");
                return usuario;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DevulveInfoUsuario: Exception = {ex.Message}");
                return null;
            }
        }
    }
}
