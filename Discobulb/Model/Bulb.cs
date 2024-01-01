using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Discobulb.Model
{
    public class Bulb
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
    }

    public class BulbState
    {
        [JsonPropertyName("on")]
        public bool IsOn { get; set; }

        [JsonPropertyName("bri")]
        public int Brightness { get; set; }

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
