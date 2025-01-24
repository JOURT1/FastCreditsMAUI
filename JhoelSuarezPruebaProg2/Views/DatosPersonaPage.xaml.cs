namespace JhoelSuarezPruebaProg2.Views;
using JhoelSuarezPruebaProg2.ViewModel;
public partial class DatosPersonaPage : ContentPage
{
    public DatosPersonaPage()
    {
        InitializeComponent();
        BindingContext = new DatosPersonaViewModel();
    }
}