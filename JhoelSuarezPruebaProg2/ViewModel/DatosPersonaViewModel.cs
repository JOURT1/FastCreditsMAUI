using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using JhoelSuarezPruebaProg2.Models;
using JhoelSuarezPruebaProg2.Services;
namespace JhoelSuarezPruebaProg2.ViewModel
{
    public class DatosPersonaViewModel : INotifyPropertyChanged
    {
        private readonly PersonaService _personaService;
        public ObservableCollection<Persona> Personas { get; set; }
        public ICommand CargarPersonasCommand { get; }
        public DatosPersonaViewModel()
        {
            _personaService = new PersonaService();
            Personas = new ObservableCollection<Persona>();
            CargarPersonasCommand = new Command(async () => await CargarPersonas());
            //CargarPersonas();
        }
        private async Task CargarPersonas()
        {
            try
            {
                var personas = await _personaService.ObtenerPersonas();
                if (personas == null || personas.Count == 0)
                {
                    await App.Current.MainPage.DisplayAlert("Aviso", "No hay personas registradas en la API.", "OK");
                    return;
                }
                Personas.Clear();
                foreach (var persona in personas)
                {
                    Personas.Add(persona);
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"Error al cargar los datos: {ex.Message}", "OK");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}