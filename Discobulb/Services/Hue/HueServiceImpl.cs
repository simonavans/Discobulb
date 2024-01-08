using Discobulb.Model;
using Q42.HueApi;
using Q42.HueApi.Models.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeroconf;

namespace Discobulb.Services.Hue
{
    public class HueServiceImpl(string bridgeAddress) : IHueService
    {
        private readonly string _bridgeAddress = bridgeAddress; 
        private LocalHueClient _hueClient = new(bridgeAddress);

        public async Task<List<BridgeConfig>> GetDetectedBridgesAsync()
        {
            var serviceType = "_hue._tcp.local";

            var results = await ZeroconfResolver.ResolveAsync(serviceType);

            return results
                .Select(raw =>
                {
                    return new BridgeConfig() { Name = raw.DisplayName, IpAddress = raw.IPAddress };
                })
                .ToList();
        }

        public async Task<bool> ConnectToBridge(string applicationName, string deviceName)
        {
            _hueClient = new(_bridgeAddress);

            try
            {
                await _hueClient.RegisterAsync(applicationName, deviceName);
            }
            catch (LinkButtonNotPressedException)
            {
                return false;
            }
            return true;
        }

        public async Task<List<LightModel>> GetLightsAsync()
        {
            return (await _hueClient.GetLightsAsync())
                .Select(l => new LightModel(l.Id, l.Name, l.State.On, l.State.Brightness, (ushort)l.State.Hue!))
                .ToList();
        }

        public async Task<bool> SetOnAsync(bool on, params LightModel[] lights)
        {
            if (lights.Length == 0) return false;

            LightCommand req = new()
            {
                On = on
            };

            HueResults res = await _hueClient.SendCommandAsync(req, lights.Select(l => l.Id));

            return res.HasErrors();
        }

        public async Task<bool> SetBrightnessAsync(byte brightness, params LightModel[] lights)
        {
            if (lights.Length == 0) return false;

            LightCommand req = new()
            {
                Brightness = brightness
            };

            HueResults res = await _hueClient.SendCommandAsync(req, lights.Select(l => l.Id));

            return res.HasErrors();
        }

        public async Task<bool> SetHueAsync(ushort hue, params LightModel[] lights)
        {
            if (lights.Length == 0) return false;

            LightCommand req = new()
            {
                Hue = hue
            };

            HueResults res = await _hueClient.SendCommandAsync(req, lights.Select(l => l.Id));

            return res.HasErrors();
        }
    }
}
