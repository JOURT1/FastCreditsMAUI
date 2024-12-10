using JhoelSuarezPruebaProg2.Interfaces;
using JhoelSuarezPruebaProg2.Models;
using JhoelSuarezPruebaProg2.Repositories;

namespace JhoelSuarezPruebaProg2.Views;

public partial class JSuarezPag1 : ContentPage
{
    //IMPORTANTE: Se inicia la interfaz
    public IJSuarezUsuarioRepository _jSuarezUsuarioRepository;
    public JSuarezUsuario usuario = new JSuarezUsuario();
    public JSuarezPag1()
	{
		InitializeComponent();
        //JSuarezUsuarioRepository jSuarezUsuarioRepository = new JSuarezUsuarioRepository();
        //var info_usuario = jSuarezUsuarioRepository.DevuelveInfoUsuario();

        //JSuarez_Label_Telefono.Text = info_usuario.Telefono.ToString();
        //JSuarez_Label_Nombre.Text = info_usuario.Nombre;

        _jSuarezUsuarioRepository = new JSuarezUsuarioRepository();

        usuario = _jSuarezUsuarioRepository.DevulveInfoUsuario("");
        BindingContext = usuario;
    }

    private async void JSuarez_btn_Recargar_Clicked(object sender, EventArgs e)
    {
        JSuarezUsuario usuario = new JSuarezUsuario
        {
            Telefono = JSuarez_editor_Telefono.Text,
            Nombre = JSuarez_editor_Nombre.Text
        };
        bool guardar = _jSuarezUsuarioRepository.CrearUsuario(usuario);

        if (guardar)
        {
            await DisplayAlert("Alerta", "Guardado correctamente", "OK");
        }
        else
        {
            await DisplayAlert("Alerta", "Error al guardar", "OK");
        }
        Navigation.PushAsync(new JSuarezPag1());

    }
}