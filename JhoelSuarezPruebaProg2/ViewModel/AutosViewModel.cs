using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace JhoelSuarezPruebaProg2.ViewModels
{
    public class AutosViewModel : INotifyPropertyChanged
    {
        private string _marca;
        private string _modelo;
        private string _año;
        private string _precio;

        public string Marca
        {
            get => _marca;
            set
            {
                _marca = value;
                OnPropertyChanged();
            }
        }

        public string Modelo
        {
            get => _modelo;
            set
            {
                _modelo = value;
                OnPropertyChanged();
            }
        }

        public string Año
        {
            get => _año;
            set
            {
                _año = value;
                OnPropertyChanged();
            }
        }

        public string Precio
        {
            get => _precio;
            set
            {
                _precio = value;
                OnPropertyChanged();
            }
        }

        public AutosViewModel()
        {
            Marca = "";
            Modelo = "";
            Año = "";
            Precio = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
