using JhoelSuarezPruebaProg2.Interfaces;
using JhoelSuarezPruebaProg2.Models;
using JhoelSuarezPruebaProg2.Repositories;

namespace JhoelSuarezPruebaProg2.Views;

public partial class Civil : ContentPage
{
    public IJSCivilRepo _jsuarezCivilRepository;
    public IJSuarezUsuarioRepository _jSuarezUsuarioRepository;
    public IJSCarroRepo _jSuarezCarroRepository;
    public JSuarezCivil civil = new JSuarezCivil();

    public Civil()
    {
        InitializeComponent();
        _jsuarezCivilRepository = new JsuarezCivilRepository();
        _jSuarezUsuarioRepository = new JSuarezUsuarioRepository();
        _jSuarezCarroRepository = new JsuarezCarroRepository();

        // Cargar la información inicial del estado civil
        civil = _jsuarezCivilRepository.DevulveInfoCivil("");
        BindingContext = civil;
    }

    private async void JSuarez_btn_Recargar_Clicked(object sender, EventArgs e)
    {
        // Crear un nuevo objeto JSuarezCivil con los datos ingresados
        JSuarezCivil civil = new JSuarezCivil
        {
            Casado = Editor_Casado.Text,
            Hijos = Editor_Hijos.Text
        };

        // Guardar el estado civil en el repositorio
        bool guardar = _jsuarezCivilRepository.CrearCivil(civil);

        if (guardar)
        {
            // Recuperar el usuario previamente registrado
            var usuario = _jSuarezUsuarioRepository.DevulveInfoUsuario("");

            // Recuperar el carro previamente registrado
            var carro = _jSuarezCarroRepository.DevulveInfoCarro("");

            // Navegar a la página JSuarezPag2 pasando los tres objetos
            await Navigation.PushAsync(new JSuarezPag2(usuario, carro, civil));
        }
        else
        {
            await DisplayAlert("Alerta", "Error al guardar el estado civil", "OK");
        }
    }
}
