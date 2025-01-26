using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using JhoelSuarezPruebaProg2.Models;
using JhoelSuarezPruebaProg2.Repositories;
using System.IO;
using System.Diagnostics;

namespace JhoelSuarezPruebaProg2.ViewModels
{
    public class AutosViewModel : INotifyPropertyChanged
    {
        private readonly JsuarezCarroRepository _carroRepository;
        private JSuarezCarro _carro;

        public JSuarezCarro Carro
        {
            get => _carro;
            set
            {
                _carro = value;
                OnPropertyChanged();
            }
        }

        public ICommand GuardarCommand { get; }

        public AutosViewModel()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "JhoelSuarez.db3");
            _carroRepository = new JsuarezCarroRepository(dbPath);
            Carro = new JSuarezCarro(); // Inicializar un nuevo carro
            GuardarCommand = new Command(OnGuardar);
        }

        private async void OnGuardar()
        {
            Debug.WriteLine($"OnGuardar: Carro = {Carro.Marca}, {Carro.Modelo}");
            bool guardado = _carroRepository.CrearCarro(Carro);

            if (guardado)
                await Application.Current.MainPage.DisplayAlert("Éxito", "Carro guardado correctamente", "OK");
            else
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo guardar el carro", "OK");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

