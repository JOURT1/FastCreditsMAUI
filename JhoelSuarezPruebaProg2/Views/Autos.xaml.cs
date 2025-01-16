using JhoelSuarezPruebaProg2.Interfaces;
using JhoelSuarezPruebaProg2.Models;
using JhoelSuarezPruebaProg2.Repositories;
using JhoelSuarezPruebaProg2.ViewModels;

namespace JhoelSuarezPruebaProg2.Views
{
    public partial class Autos : ContentPage
    {
        public IJSCarroRepo _jSuarezCarroRepository;

        public Autos()
        {
            InitializeComponent();
            _jSuarezCarroRepository = new JsuarezCarroRepository();
        }

        private async void JSuarez_btn_Recargar_Clicked(object sender, EventArgs e)
        {
            var viewModel = (AutosViewModel)BindingContext;

            // Crear un nuevo objeto JSuarezCarro con los datos ingresados
            JSuarezCarro carro = new JSuarezCarro
            {
                Marca = viewModel.Marca,
                Modelo = viewModel.Modelo,
                Año = viewModel.Año,
                Precio = viewModel.Precio
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
}
