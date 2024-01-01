using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Discobulb.Model;
using Discobulb.Services.Request;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml;

namespace Discobulb.ViewModel
{
    public partial class MainPageViewModel(IRequestService requestService) : ObservableObject
    {
        private readonly IRequestService _requestService = requestService;

        [ObservableProperty]
        private ObservableCollection<Bulb> _bulbs = [];

        public async Task LoadBulbsAsync()
        {
            JsonObject? jsonBulbs = await _requestService.GetJsonObjectAsync("lights");
            if (jsonBulbs == null) return;

            foreach (var jsonPair in jsonBulbs)
            {
                string jsonString = JsonSerializer.Serialize(jsonPair.Value);
                Bulb? bulb = JsonSerializer.Deserialize<Bulb>(jsonString);

                if (bulb != null)
                {
                    bulb.JsonIndex = int.Parse(jsonPair.Key);
                    Bulbs.Add(bulb);
                }
            }
        }

        public Bulb? GetBulbFromCache(string uniqueId)
        {
            return
                (from _bulb in Bulbs
                where _bulb.UniqueId == uniqueId
                select _bulb)
                .FirstOrDefault();
        }

        public Bulb? GetBulbFromCache(int jsonIndex)
        {
            return
                (from _bulb in Bulbs
                 where _bulb.JsonIndex == jsonIndex
                 select _bulb)
                .FirstOrDefault();
        }

        public async Task ToggleBulbAsync(Bulb bulb)
        {
            bool requestedState = !bulb.State.IsOn;
            JsonObject payload = new() { { "on", requestedState } };

            if (await _requestService.PutJsonAsync($"lights/{bulb.JsonIndex}", payload))
                bulb.State.IsOn = requestedState;
            else
                await Shell.Current.DisplayAlert("Request failed", "Could not alter this bulb, likely due to connectivity problems.", "OK");
        }

        public async Task SetBrightnessAsync(Bulb bulb, byte brightness)
        {
            JsonObject payload = new() { { "bri", brightness } };

            if (await _requestService.PutJsonAsync($"lights/{bulb.JsonIndex}", payload))
                bulb.State.Brightness = brightness;
            else
                await Shell.Current.DisplayAlert("Request failed", "Could not alter this bulb, likely due to connectivity problems.", "OK");
        }

        public async Task SetHueAsync(Bulb bulb, int hue)
        {
            JsonObject payload = new() { { "hue", hue } };

            if (await _requestService.PutJsonAsync($"lights/{bulb.JsonIndex}", payload))
                bulb.State.Hue = hue;
            else
                await Shell.Current.DisplayAlert("Request failed", "Could not alter this bulb, likely due to connectivity problems.", "OK");
        }
    }
}
