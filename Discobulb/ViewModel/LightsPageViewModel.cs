using CommunityToolkit.Mvvm.ComponentModel;
using Discobulb.Model;
using Discobulb.Services.Hue;
using System.Collections.ObjectModel;

namespace Discobulb.ViewModel
{
    public partial class LightsPageViewModel(IHueService hueService) : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<BridgeModel> _bridges = [];

        [ObservableProperty]
        private ObservableCollection<LightModel> _lights = [];

        [ObservableProperty]
        private ObservableCollection<LightModel> _selectedLights = [];

        private readonly IHueService _hueService = hueService;

        public async Task<bool> ConnectToBridge(string bridgeAddress, string applicationName, string deviceName)
        {
            return await _hueService.ConnectToBridge(bridgeAddress, applicationName, deviceName);
        }

        public async Task LoadLightsAsync()
        {
            List<LightModel> lights = await _hueService.GetLightsAsync();

            Lights.Clear();

            foreach (LightModel light in lights)
            {
                Lights.Add(light);
            }
        }

        public async Task<bool> SetOnAsync(bool on, LightModel light)
        {
            LightModel[] lightsToUpdate = new LightModel[Math.Max(SelectedLights.Count, 1)];

            if (SelectedLights.Contains(light))
                lightsToUpdate = [.. SelectedLights];
            else
                lightsToUpdate[0] = light;

            if (!await _hueService.SetOnAsync(on, [.. lightsToUpdate]))
            {
                foreach (var _light in lightsToUpdate)
                    _light.On = on;
                return true;
            }
            return false;
        }

        public async Task<bool> SetBrightnessAsync(byte brightness, LightModel light)
        {
            LightModel[] lightsToUpdate = new LightModel[Math.Max(SelectedLights.Count, 1)];

            if (SelectedLights.Contains(light))
                lightsToUpdate = [.. SelectedLights];
            else
                lightsToUpdate[0] = light;

            if (!await _hueService.SetBrightnessAsync(brightness, [.. lightsToUpdate]))
            {
                foreach (var _light in lightsToUpdate)
                    _light.Brightness = brightness;
                return true;
            }
            return false;
        }

        public async Task<bool> SetHueAsync(ushort hue, LightModel light)
        {
            LightModel[] lightsToUpdate = new LightModel[Math.Max(SelectedLights.Count, 1)];

            if (SelectedLights.Contains(light))
                lightsToUpdate = [.. SelectedLights];
            else
                lightsToUpdate[0] = light;

            if (!await _hueService.SetHueAsync(hue, [.. lightsToUpdate]))
            {
                foreach (var _light in lightsToUpdate)
                    _light.Hue = hue;
                return true;
            }
            return false;
        }

        public void SetLightSelected(bool selected, LightModel light)
        {
            if (selected && !SelectedLights.Contains(light))
                SelectedLights.Add(light);
            else if (!selected)
                SelectedLights.Remove(light);
        }
    }
}
