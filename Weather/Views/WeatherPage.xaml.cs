using Weather.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage {
        public WeatherPage() {
            InitializeComponent();
            BindingContext = new WeatherPageVM();
        }
    }
}