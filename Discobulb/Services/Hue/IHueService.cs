using Discobulb.Model;
using Q42.HueApi;

namespace Discobulb.Services.Hue
{
    public interface IHueService
    {
        Task<List<BridgeConfig>> GetDetectedBridgesAsync();
        Task<bool> ConnectToBridge(string bridgeAddress, string applicationName, string deviceName);
        Task<List<LightModel>> GetLightsAsync();
        Task<bool> SetOnAsync(bool on, params LightModel[] lights);
        Task<bool> SetBrightnessAsync(byte brightness, params LightModel[] lights);
        Task<bool> SetHueAsync(ushort hue, params LightModel[] lights);
    }
}
