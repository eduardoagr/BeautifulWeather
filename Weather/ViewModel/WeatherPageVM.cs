using Newtonsoft.Json;

using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;

using Weather.Model;

using Xamarin.Forms;

namespace Weather.ViewModel {
    public class WeatherPageVM : ViewModelBase {


        private WeatherData _Data;
        public WeatherData Data {
            get { return _Data; }
            set {
                if (_Data != value) {
                    _Data = value;
                    RaisePropertyChanged();
                }
            }
        }
        public ICommand SearchCommand { get; set; }

        public WeatherPageVM() {

            SearchCommand = new Command(async (searchTerm) => {

                var term = searchTerm as string;
                var data = term.Split(',');
                var lat = data[0];
                var lon = data[1];
                await GetData($"https://api.weatherbit.io/v2.0/current?lat={lat}&lon={lon}&key=d51cc2931ead4b0682c4e7358a979b70");

            });
        }

        private async Task GetData(string url) {

            using (HttpClient client = new HttpClient()) {

                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var jsonResult = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<WeatherData>(jsonResult);
                Data = result;

            }
        }
    }
}