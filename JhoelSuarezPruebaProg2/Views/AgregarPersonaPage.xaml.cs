namespace JhoelSuarezPruebaProg2.Views;
using JhoelSuarezPruebaProg2.ViewModel;
public partial class AgregarPersonaPage : ContentPage
{
    public AgregarPersonaPage()
    {
        InitializeComponent();
        BindingContext = new AgregarPersonaViewModel();
    }
}