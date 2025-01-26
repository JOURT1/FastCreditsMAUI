using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using JhoelSuarezPruebaProg2.Models;
using JhoelSuarezPruebaProg2.Repositories;
using System.IO;
using System.Diagnostics;

namespace JhoelSuarezPruebaProg2.ViewModels
{
    public class CivilViewModel : INotifyPropertyChanged
    {
        private readonly JsuarezCivilRepository _civilRepository;
        private JSuarezCivil _civil;

        public JSuarezCivil Civil
        {
            get => _civil;
            set
            {
                _civil = value;
                OnPropertyChanged();
            }
        }

        public ICommand GuardarCommand { get; }

        public CivilViewModel()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "JhoelSuarez.db3");
            _civilRepository = new JsuarezCivilRepository(dbPath);
            Civil = new JSuarezCivil(); // Inicializar un nuevo civil
            GuardarCommand = new Command(OnGuardar);
        }

        private async void OnGuardar()
        {
            Debug.WriteLine($"OnGuardar: Civil = {Civil.Casado}, {Civil.Hijos}");
            bool guardado = _civilRepository.CrearCivil(Civil);

            if (guardado)
                await Application.Current.MainPage.DisplayAlert("Éxito", "Datos civiles guardados correctamente", "OK");
            else
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudieron guardar los datos civiles", "OK");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
