using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using JhoelSuarezPruebaProg2.Models;
using System.Net.Http.Json;
using Newtonsoft.Json;
namespace JhoelSuarezPruebaProg2.ViewModel
{
    public class AgregarPersonaViewModel : INotifyPropertyChanged
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrlCreate = "https://localhost:7293/Personas/Create"; // URL de la API CREATE
        private string _cedula;
        private string _nombre;
        private string _edad;
        private DateTime _fechaNacimiento;
        private string _genero;
        private string _telefono;
        private string _correo;
        public List<string> Generos { get; } = new List<string> { "Masculino", "Femenino" }; // Opciones del Picker
        public string Cedula
        {
            get => _cedula;
            set { _cedula = value?.Trim(); OnPropertyChanged(); }
        }
        public string Nombre
        {
            get => _nombre;
            set { _nombre = value?.Trim(); OnPropertyChanged(); }
        }
        public string Edad
        {
            get => _edad;
            set { _edad = value?.Trim(); OnPropertyChanged(); }
        }
        public DateTime FechaNacimiento
        {
            get => _fechaNacimiento;
            set { _fechaNacimiento = value; OnPropertyChanged(); }
        }
        public string Genero
        {
            get => _genero;
            set { _genero = value; OnPropertyChanged(); }
        }
        public string Telefono
        {
            get => _telefono;
            set { _telefono = value?.Trim(); OnPropertyChanged(); }
        }
        public string Correo
        {
            get => _correo;
            set { _correo = value?.Trim(); OnPropertyChanged(); }
        }
        public ICommand AgregarPersonaCommand { get; }
        public AgregarPersonaViewModel()
        {
            _httpClient = new HttpClient();
            AgregarPersonaCommand = new Command(async () => await AgregarPersona());
            FechaNacimiento = DateTime.Today.Date; // Se asegura que sea a medianoche
            Genero = "Masculino"; // Valor por defecto
        }
        private async Task AgregarPersona()
        {
            int edad = 0;
            // Imprimir valores en consola para depuración
            Console.WriteLine($"Cedula: {Cedula}");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Edad: {Edad}");
            Console.WriteLine($"FechaNacimiento: {FechaNacimiento}");
            Console.WriteLine($"Genero: {Genero}");
            Console.WriteLine($"Telefono: {Telefono}");
            Console.WriteLine($"Correo: {Correo}");
            // Asegurar que la fecha tenga hora 00:00:00
            DateTime fechaNacimiento = new DateTime(FechaNacimiento.Year, FechaNacimiento.Month, FechaNacimiento.Day, 0, 0, 0);
            // Validaciones corregidas
            bool cedulaValida = !string.IsNullOrWhiteSpace(Cedula) && Cedula.Length == 10 && Cedula.All(char.IsDigit);
            bool nombreValido = !string.IsNullOrWhiteSpace(Nombre) && Nombre.Length >= 3;
            bool edadValida = int.TryParse(Edad, out edad) && edad >= 1 && edad <= 100;
            bool telefonoValido = !string.IsNullOrWhiteSpace(Telefono) && Telefono.Length == 10 && Telefono.All(char.IsDigit);
            bool correoValido = !string.IsNullOrWhiteSpace(Correo) &&
                                Correo.Contains("@") &&
                                Correo.Contains(".") &&
                                Correo.IndexOf("@") < Correo.LastIndexOf(".");
            bool generoValido = !string.IsNullOrWhiteSpace(Genero) && (Genero == "Masculino" || Genero == "Femenino");
            if (!cedulaValida || !nombreValido || !edadValida || !telefonoValido || !correoValido || !generoValido)
            {
                string mensajeError = "Todos los campos son obligatorios y deben cumplir con el formato correcto.\n\n";
                mensajeError += cedulaValida ? "✔ Cédula: 10 dígitos.\n" : "❌ Cédula incorrecta. Debe contener solo números y tener 10 dígitos.\n";
                mensajeError += nombreValido ? "✔ Nombre: mínimo 3 letras.\n" : "❌ Nombre debe tener al menos 3 letras.\n";
                mensajeError += edadValida ? "✔ Edad: entre 1 y 100 años.\n" : "❌ Edad inválida. Debe ser un número entre 1 y 100.\n";
                mensajeError += telefonoValido ? "✔ Teléfono: 10 dígitos.\n" : "❌ Teléfono debe tener 10 dígitos y solo números.\n";
                mensajeError += correoValido ? "✔ Correo: formato válido (ejemplo@dominio.com).\n" : "❌ Correo inválido. Verifica que tenga '@' y un dominio correcto.\n";
                mensajeError += generoValido ? "✔ Género seleccionado.\n" : "❌ Debe seleccionar un género.\n";
                await App.Current.MainPage.DisplayAlert("Error", mensajeError, "OK");
                return;
            }
            // Crear objeto persona
            var persona = new Persona
            {
                Cedula = Cedula,
                Nombre = Nombre,
                Edad = edad,
                Fecha_Nacimiento = fechaNacimiento,
                Genero = Genero,
                Telefono = Telefono,
                Correo = Correo
            };
            // Enviar la persona a la API
            try
            {
                var response = await _httpClient.PostAsJsonAsync(ApiUrlCreate, persona);
                if (response.IsSuccessStatusCode)
                {
                    await App.Current.MainPage.DisplayAlert("Éxito", "Persona agregada correctamente", "OK");
                    LimpiarCampos();
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    await App.Current.MainPage.DisplayAlert("Error", $"Error al enviar los datos: {error}", "OK");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"No se pudo conectar con la API: {ex.Message}", "OK");
            }
        }
        private void LimpiarCampos()
        {
            Cedula = string.Empty;
            Nombre = string.Empty;
            Edad = string.Empty;
            FechaNacimiento = DateTime.Today;
            Genero = "Masculino"; // Reinicia la selección de género
            Telefono = string.Empty;
            Correo = string.Empty;
            OnPropertyChanged(nameof(Cedula));
            OnPropertyChanged(nameof(Nombre));
            OnPropertyChanged(nameof(Edad));
            OnPropertyChanged(nameof(FechaNacimiento));
            OnPropertyChanged(nameof(Genero));
            OnPropertyChanged(nameof(Telefono));
            OnPropertyChanged(nameof(Correo));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}