using System.ComponentModel;
using System.Runtime.CompilerServices;
using JhoelSuarezPruebaProg2.Models;
using JhoelSuarezPruebaProg2.Repositories;
using System.Windows.Input;
using JhoelSuarezPruebaProg2.Interfaces;


namespace JhoelSuarezPruebaProg2.ViewModels
{
    public class CivilViewModel : INotifyPropertyChanged
    {
        private readonly IJSCivilRepo _jsuarezCivilRepository;

        private string _casado;
        private string _hijos;

        public string Casado
        {
            get => _casado;
            set
            {
                _casado = value;
                OnPropertyChanged();
            }
        }

        public string Hijos
        {
            get => _hijos;
            set
            {
                _hijos = value;
                OnPropertyChanged();
            }
        }

        public ICommand GuardarCommand { get; }

        public CivilViewModel()
        {
            _jsuarezCivilRepository = new JsuarezCivilRepository();

            // Cargar la información inicial del estado civil
            var civil = _jsuarezCivilRepository.DevulveInfoCivil("");
            Casado = civil.Casado;
            Hijos = civil.Hijos;

            // Asociar el comando
            GuardarCommand = new Command(OnGuardar);
        }

        private async void OnGuardar()
        {
            JSuarezCivil civil = new JSuarezCivil
            {
                Casado = Casado,
                Hijos = Hijos
            };

            bool guardado = _jsuarezCivilRepository.CrearCivil(civil);

            if (guardado)
            {
                await Application.Current.MainPage.DisplayAlert("Alerta", "Guardado correctamente", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Alerta", "Error al guardar el estado civil", "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
