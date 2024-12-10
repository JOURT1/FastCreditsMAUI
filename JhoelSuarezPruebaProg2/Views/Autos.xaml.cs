using JhoelSuarezPruebaProg2.Interfaces;
using JhoelSuarezPruebaProg2.Models;
using JhoelSuarezPruebaProg2.Repositories;

namespace JhoelSuarezPruebaProg2.Views;

public partial class Autos : ContentPage
{
    public IJSCarroRepo _jSuarezCarroRepository;
    public IJSuarezUsuarioRepository _jSuarezUsuarioRepository;
    public JSuarezCarro carro = new JSuarezCarro();

    public Autos()
    {
        InitializeComponent();
        _jSuarezCarroRepository = new JsuarezCarroRepository();
        _jSuarezUsuarioRepository = new JSuarezUsuarioRepository();
        carro = _jSuarezCarroRepository.DevulveInfoCarro("");
        BindingContext = carro;
    }

    private async void JSuarez_btn_Recargar_Clicked(object sender, EventArgs e)
    {
        JSuarezCarro carro = new JSuarezCarro
        {
            Marca = Editor_Marca.Text,
            Modelo = Editor_Modelo.Text,
            Año = Editor_Año.Text,
            Precio = Editor_Precio.Text
        };

        bool guardar = _jSuarezCarroRepository.CrearCarro(carro);

        if (guardar)
        {
            await DisplayAlert("Alerta", "Guardado correctamente", "OK");

        }
        else
        {
            await DisplayAlert("Alerta", "Error al guardar", "OK");
        }
    }
}
