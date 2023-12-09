using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Discobulb.Model;
using Discobulb.Services.Request;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Discobulb.ViewModel
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Bulb> _bulbs = [];

        private readonly IRequestService _requestService;

        public MainPageViewModel(IRequestService requestService)
        {
            _requestService = requestService;
        }

        /// <summary>
        /// TODO comment
        /// </summary>
        /// <returns></returns>
        public async Task LoadBulbsAsync()
        {
            ObservableCollection<Bulb> bulbs = [];

            JsonObject? bulbsAsObject = await _requestService.GetJsonObjectAsync("lights");
            if (bulbsAsObject == null) return;

            // The lights object contains each light object, but should be an array and not an object. So, convert it.
            JsonArray bulbsJsonArray = JsonObjectToBulbsArray(bulbsAsObject);

            foreach (var item in bulbsJsonArray)
            {
                if (item is not JsonObject itemObject) continue;

                Bulb? bulb = CreateBulbFromJson(itemObject);
                if (bulb != null) bulbs.Add(bulb);
            }

            Bulbs = bulbs;
        }

        public async Task<Bulb?> GetBulbAsync(int index)
        {
            JsonObject? jsonBulb = await _requestService.GetJsonObjectAsync($"lights/{index}");
            if (jsonBulb == null) return null;

            return CreateBulbFromJson(jsonBulb);
        }

        /// <summary>
        /// TODO comment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Bulb?> GetBulbAsync(string id)
        {
            JsonObject? bulbsAsObject = await _requestService.GetJsonObjectAsync("lights");
            if (bulbsAsObject == null) return null;

            JsonArray bulbsJsonArray = JsonObjectToBulbsArray(bulbsAsObject);

            foreach (var item in bulbsJsonArray)
            {
                if (item == null) continue;

                JsonNode? idNode = item["uniqueid"];
                if (idNode == null) continue;

                if (idNode.ToString() == id)
                {
                    if (item is not JsonObject itemObject) continue;
                    return CreateBulbFromJson(itemObject);
                }
            }
            return null;
        }

        public async Task ToggleIsOnAsync(Bulb bulb)
        {
            Bulb? possibleBulb = await GetBulbAsync(bulb.Id);
            if (possibleBulb == null) return;

            JsonObject param = new() {{ "on", !bulb.IsOn }};

            if (!await _requestService.PutJsonAsync($"lights/{possibleBulb.Index}", param))
            {
                // TODO show error
            }
        }

        public async Task SetBrightnessAsync(Bulb bulb, byte brightness)
        {
            Bulb? possibleBulb = await GetBulbAsync(bulb.Id);
            if (possibleBulb == null) return;

            JsonObject param = new() { { "on", brightness } };

            if (!await _requestService.PutJsonAsync($"lights/{possibleBulb.Index}", param))
            {
                // TODO show error
            }
        }

        public async Task SetHueAsync(Bulb bulb, int hue)
        {
            Bulb? possibleBulb = await GetBulbAsync(bulb.Id);
            if (possibleBulb == null) return;

            JsonObject param = new() { { "on", hue } };

            if (!await _requestService.PutJsonAsync($"lights/{possibleBulb.Index}", param))
            {
                // TODO show error
            }
        }

        /// <summary>
        /// TODO comment
        /// </summary>
        /// <param name="bulbAsJson"></param>
        /// <returns></returns>
        private static Bulb? CreateBulbFromJson(JsonObject bulbAsJson)
        {
            try
            {
                return new Bulb(
                    bulbAsJson["uniqueid"].ToString(),
                    int.Parse(bulbAsJson.ToString()),
                    bulbAsJson["name"].ToString(),
                    bool.Parse(bulbAsJson["state"]["on"].ToString()),
                    bool.Parse(bulbAsJson["state"]["reachable"].ToString()),
                    byte.Parse(bulbAsJson["state"]["bri"].ToString()),
                    int.Parse(bulbAsJson["state"]["hue"].ToString())
                );
            }
            catch (Exception ex) when (
                ex is NullReferenceException ||
                ex is FormatException)
            {
                return null;
            }
        }

        /// <summary>
        /// TODO comment
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        private static JsonArray JsonObjectToBulbsArray(JsonObject json)
        {
            JsonArray bulbsArray = [];

            foreach (var item in json)
            {
                if (!int.TryParse(item.Key, out _)) continue;

                JsonObject? jsonBulb = item.Value as JsonObject;
                if (jsonBulb == null) continue;

                bulbsArray.Add(jsonBulb);
            }

            return bulbsArray;
        }
    }
}
