using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using JhoelSuarezPruebaProg2.Models;
using JhoelSuarezPruebaProg2.Repositories;
using System.IO;
using System.Diagnostics;

namespace JhoelSuarezPruebaProg2.ViewModels
{
    public class PersonaViewModel : INotifyPropertyChanged
    {
        private readonly JSuarezUsuarioRepository _usuarioRepository;
        private JSuarezUsuario _usuario;

        public JSuarezUsuario Usuario
        {
            get => _usuario;
            set
            {
                _usuario = value;
                OnPropertyChanged();
            }
        }

        public ICommand GuardarCommand { get; }

        public PersonaViewModel()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "JhoelSuarez.db3");
            _usuarioRepository = new JSuarezUsuarioRepository(dbPath);
            Usuario = new JSuarezUsuario(); // Inicializar un nuevo usuario
            GuardarCommand = new Command(OnGuardar);
        }

        private async void OnGuardar()
        {
            Debug.WriteLine($"OnGuardar: Usuario = {Usuario.Nombre}, {Usuario.Telefono}");
            bool guardado = _usuarioRepository.CrearUsuario(Usuario);

            if (guardado)
                await Application.Current.MainPage.DisplayAlert("Éxito", "Usuario guardado correctamente", "OK");
            else
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo guardar el usuario", "OK");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
