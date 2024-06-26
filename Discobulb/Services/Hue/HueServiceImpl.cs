﻿using Discobulb.Model;
using Q42.HueApi;
using Q42.HueApi.Models.Groups;
using Zeroconf;

namespace Discobulb.Services.Hue
{
    public class HueServiceImpl : IHueService
    {
        private LocalHueClient _hueClient;

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

        public async Task<bool> ConnectToBridge(string bridgeAddress, string applicationName, string deviceName)
        {
            _hueClient = new(bridgeAddress);

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
                .Select(l => new LightModel(
                    l.Id,
                    l.Name, 
                    l.State.On, 
                    l.State.Brightness, 
                    (ushort)l.State.Hue!,
                    l.Type,
                    l.ModelId)
                )
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
