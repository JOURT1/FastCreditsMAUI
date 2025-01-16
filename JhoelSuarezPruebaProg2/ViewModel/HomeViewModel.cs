using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace JhoelSuarezPruebaProg2.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private string _welcomeMessage;
        private string _descriptionMessage;

        public string WelcomeMessage
        {
            get => _welcomeMessage;
            set
            {
                _welcomeMessage = value;
                OnPropertyChanged();
            }
        }

        public string DescriptionMessage
        {
            get => _descriptionMessage;
            set
            {
                _descriptionMessage = value;
                OnPropertyChanged();
            }
        }

        public HomeViewModel()
        {
            WelcomeMessage = "Bienvenido a FastCredits";
            DescriptionMessage = "Tu camino hacia el auto de tus sueños comienza aquí";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
