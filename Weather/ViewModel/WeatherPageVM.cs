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

                await GetData(Constants.URL);

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