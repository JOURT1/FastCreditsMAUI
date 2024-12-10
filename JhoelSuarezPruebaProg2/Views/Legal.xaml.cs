using JhoelSuarezPruebaProg2.Interfaces;
using JhoelSuarezPruebaProg2.Models;
using JhoelSuarezPruebaProg2.Repositories;

namespace JhoelSuarezPruebaProg2.Views;

public partial class Legal : ContentPage
{
    public IJSLegalRepo _jsuarezLegalRepository;
    public IJSCivilRepo _jsuarezCivilRepository;
    public IJSuarezUsuarioRepository _jSuarezUsuarioRepository;
    public IJSCarroRepo _jSuarezCarroRepository;
    public JSuarezLegal legal = new JSuarezLegal();

    public Legal()
    {
        InitializeComponent();
        _jsuarezLegalRepository = new JsuarezLegalRepository();
        _jsuarezCivilRepository = new JsuarezCivilRepository();
        _jSuarezUsuarioRepository = new JSuarezUsuarioRepository();
        _jSuarezCarroRepository = new JsuarezCarroRepository();

        // Cargar la información inicial del estado civil
        legal = _jsuarezLegalRepository.DevulveInfoLegal("");
        BindingContext = legal;
    }

    private async void JSuarez_btn_Recargar_Clicked(object sender, EventArgs e)
    {
        // Crear un nuevo objeto JSuarezCivil con los datos ingresados
        JSuarezLegal legal = new JSuarezLegal
        {
            Denuncias = Editor_Denuncias.Text,
            Antecedentes_Penales = Editor_Antecedentes.Text,
            Fraudes = Editor_Fraudes.Text
        };

        // Guardar el estado civil en el repositorio
        bool guardar = _jsuarezLegalRepository.CrearLegal(legal);

        if (guardar)
        {
            await DisplayAlert("Alerta", "Guardado correctamente", "OK");
        }
        else
        {
            await DisplayAlert("Alerta", "Error al guardar el estado civil", "OK");
        }
    }

    private async void JSuarez_btn_Solicitud_Clicked(object sender, EventArgs e)
    {
        // Crear un nuevo objeto JSuarezCivil con los datos ingresados
        JSuarezLegal legal = new JSuarezLegal
        {
            Denuncias = Editor_Denuncias.Text,
            Antecedentes_Penales = Editor_Antecedentes.Text,
            Fraudes = Editor_Fraudes.Text
        };

        // Guardar el estado civil en el repositorio
        bool guardar = _jsuarezLegalRepository.CrearLegal(legal);

        if (guardar)
        {
            // Recuperar el usuario previamente registrado
            var usuario = _jSuarezUsuarioRepository.DevulveInfoUsuario("");

            // Recuperar el carro previamente registrado
            var carro = _jSuarezCarroRepository.DevulveInfoCarro("");
            // Recuperar el civil previamente registrado
            var civil = _jsuarezCivilRepository.DevulveInfoCivil("");

            // Navegar a la página JSuarezPag2 pasando los tres objetos
            await Navigation.PushAsync(new JSuarezPag2(usuario, carro, civil, legal));
        }
        else
        {
            await DisplayAlert("Alerta", "Error al guardar el estado civil", "OK");
        }
    }
}
