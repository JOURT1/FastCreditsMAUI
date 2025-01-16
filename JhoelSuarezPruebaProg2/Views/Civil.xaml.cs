using JhoelSuarezPruebaProg2.ViewModels;

namespace JhoelSuarezPruebaProg2.Views
{
    public partial class Civil : ContentPage
    {
        public Civil()
        {
            InitializeComponent();
            BindingContext = new CivilViewModel(); // Vincula el ViewModel
        }
    }
}
