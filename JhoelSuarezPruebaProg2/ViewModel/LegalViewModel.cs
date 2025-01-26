using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using JhoelSuarezPruebaProg2.Models;
using JhoelSuarezPruebaProg2.Repositories;
using System.IO;
using System.Diagnostics;

namespace JhoelSuarezPruebaProg2.ViewModels
{
    public class LegalViewModel : INotifyPropertyChanged
    {
        private readonly JsuarezLegalRepository _legalRepository;
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

        public LegalViewModel()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "JhoelSuarez.db3");
            _legalRepository = new JsuarezLegalRepository(dbPath);
            Legal = new JSuarezLegal(); // Inicializar un nuevo legal
            GuardarCommand = new Command(OnGuardar);
        }

        private async void OnGuardar()
        {
            Debug.WriteLine($"OnGuardar: Legal = {Legal.Denuncias}, {Legal.Antecedentes_Penales}, {Legal.Fraudes}");
            bool guardado = _legalRepository.CrearLegal(Legal);

            if (guardado)
                await Application.Current.MainPage.DisplayAlert("Éxito", "Datos legales guardados correctamente", "OK");
            else
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudieron guardar los datos legales", "OK");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

