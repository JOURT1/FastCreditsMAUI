using JhoelSuarezPruebaProg2.Interfaces;
using JhoelSuarezPruebaProg2.Models;
using JhoelSuarezPruebaProg2.Repositories;

namespace JhoelSuarezPruebaProg2.Views;


public partial class Persona : ContentPage
{
    // Evento que notificará cuando se hayan enviado los datos
    public event EventHandler<JSuarezUsuario> DatosEnviados;

    public IJSuarezUsuarioRepository _jSuarezUsuarioRepository;
    public JSuarezUsuario usuario = new JSuarezUsuario();

    public Persona()
    {
        InitializeComponent();
        _jSuarezUsuarioRepository = new JSuarezUsuarioRepository();
        usuario = _jSuarezUsuarioRepository.DevulveInfoUsuario("");
        BindingContext = usuario;
    }

    private async void JSuarez_btn_Recargar_Clicked(object sender, EventArgs e)
    {
        JSuarezUsuario usuario = new JSuarezUsuario
        {
            Cedula = Editor_Cedula.Text,
            Nombre = Editor_Nombre.Text,
            Edad = Editor_Edad.Text,
            Fecha_Nacimiento = Editor_Fecha.Text,
            Genero = Editor_Genero.Text,
            Telefono = Editor_Telefono.Text,
            Correo = Editor_Correo.Text
        };

        bool guardar = _jSuarezUsuarioRepository.CrearUsuario(usuario);

        if (guardar)
        {
            await DisplayAlert("Alerta", "Guardado correctamente", "OK");

            // Aquí pasamos el objeto usuario a la nueva página
            //await Navigation.PushAsync(new JSuarezPag2(usuario));
            DatosEnviados?.Invoke(this, usuario);
        }
        else
        {
            await DisplayAlert("Alerta", "Error al guardar", "OK");
        }
    }
}
