using System.Net.Http.Json;
using System.Text;

namespace Discobulb
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            using var client = new HttpClient();

            string apiUrl = "http://localhost/api/newdeveloper/lights/1/state";

            HttpContent content = new StringContent($"{{ \"bri\": {new Random().Next(0, 100)} }}", Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                ResponseLabel.Text = jsonString;
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }
    }

}
