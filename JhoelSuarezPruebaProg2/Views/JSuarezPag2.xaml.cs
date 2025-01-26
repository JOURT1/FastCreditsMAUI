using JhoelSuarezPruebaProg2.Models;

namespace JhoelSuarezPruebaProg2.Views;

public partial class JSuarezPag2 : ContentPage
{
    public JSuarezPag2(JSuarezUsuario usuario, JSuarezCarro carro, JSuarezCivil civil,JSuarezLegal legal)
    {
        InitializeComponent();

        // Crear el objeto combinado y asignarlo como BindingContext
        var datosCombinados = new JSuarezDatosCombinados
        {
            Usuario = usuario,
            
            
           
        };

        BindingContext = datosCombinados;
    }
}
