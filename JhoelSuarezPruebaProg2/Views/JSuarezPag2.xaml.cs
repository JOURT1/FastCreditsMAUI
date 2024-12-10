using JhoelSuarezPruebaProg2.Models;

namespace JhoelSuarezPruebaProg2.Views;

public partial class JSuarezPag2 : ContentPage
{
	public JSuarezPag2(JSuarezUsuario usuario)
	{
		InitializeComponent();
        BindingContext = usuario;
    }


}