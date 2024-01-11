using CommunityToolkit.Mvvm.ComponentModel;
using System.Text.Json.Serialization;

namespace Discobulb.Model
{
    public partial class Bulb : ObservableObject
    {
        [JsonPropertyName("state")]
        public BulbState State { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("modelid")]
        public string? ModelId { get; set; }

        [JsonPropertyName("swversion")]
        public string? SoftwareVersion { get; set; }

        [JsonPropertyName("uniqueid")]
        public string? UniqueId { get; set; }

        public int? JsonIndex { get; set; }

        [ObservableProperty]
        private bool _isSelected;
    }

    public partial class BulbState : ObservableObject
    {
        [JsonPropertyName("on")]
        public bool IsOn { get; set; }

        [JsonPropertyName("bri"), ObservableProperty]
        private int brightness;

        [JsonPropertyName("hue")]
        public int Hue { get; set; }

        [JsonPropertyName("sat")]
        public int Saturation { get; set; }

        [JsonPropertyName("xy")]
        public float[]? Coordinates { get; set; }

        [JsonPropertyName("ct")]
        public int CT { get; set; }

        [JsonPropertyName("alert")]
        public string? Alert { get; set; }

        [JsonPropertyName("effect")]
        public string? Effect { get; set; }

        [JsonPropertyName("colormode")]
        public string? ColorMode { get; set; }

        [JsonPropertyName("reachable")]
        public bool IsReachable { get; set; }
    }
}
