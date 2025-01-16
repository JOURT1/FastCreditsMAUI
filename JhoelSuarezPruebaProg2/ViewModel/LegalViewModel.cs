using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using JhoelSuarezPruebaProg2.Models;
using JhoelSuarezPruebaProg2.Repositories;
using JhoelSuarezPruebaProg2.Views;


namespace JhoelSuarezPruebaProg2.ViewModels
{
    public class LegalViewModel : INotifyPropertyChanged
    {
        private readonly JsuarezLegalRepository _legalRepository;
        private readonly JSuarezUsuarioRepository _usuarioRepository;
        private readonly JsuarezCivilRepository _civilRepository;
        private readonly JsuarezCarroRepository _carroRepository;

        private JSuarezLegal _legal;

        public JSuarezLegal Legal
        {
            get => _legal;
            set
            {
                _legal = value;
                OnPropertyChanged();
            }
        }

        public ICommand GuardarCommand { get; }
        public ICommand GenerarSolicitudCommand { get; }

        public LegalViewModel()
        {
            _legalRepository = new JsuarezLegalRepository();
            _usuarioRepository = new JSuarezUsuarioRepository();
            _civilRepository = new JsuarezCivilRepository();
            _carroRepository = new JsuarezCarroRepository();

            Legal = _legalRepository.DevulveInfoLegal(string.Empty);

            GuardarCommand = new Command(OnGuardar);
            GenerarSolicitudCommand = new Command(OnGenerarSolicitud);
        }

        private async void OnGuardar()
        {
            bool guardado = _legalRepository.CrearLegal(Legal);

            if (guardado)
            {
                await Application.Current.MainPage.DisplayAlert("Éxito", "Datos legales guardados correctamente", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudieron guardar los datos legales", "OK");
            }
        }

        private async void OnGenerarSolicitud()
        {
            bool guardado = _legalRepository.CrearLegal(Legal);

            if (guardado)
            {
                var usuario = _usuarioRepository.DevulveInfoUsuario(string.Empty);
                var carro = _carroRepository.DevulveInfoCarro(string.Empty);
                var civil = _civilRepository.DevulveInfoCivil(string.Empty);

                await Application.Current.MainPage.Navigation.PushAsync(new JSuarezPag2(usuario, carro, civil, Legal));
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudieron guardar los datos legales", "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
