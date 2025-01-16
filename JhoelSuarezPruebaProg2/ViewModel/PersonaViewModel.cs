using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using JhoelSuarezPruebaProg2.Models;
using JhoelSuarezPruebaProg2.Repositories;

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
            _usuarioRepository = new JSuarezUsuarioRepository();
            Usuario = _usuarioRepository.DevulveInfoUsuario(string.Empty);
            GuardarCommand = new Command(OnGuardar);
        }

        private async void OnGuardar()
        {
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
