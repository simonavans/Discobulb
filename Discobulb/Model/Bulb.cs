using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discobulb.Model
{
    public class Bulb(
        string id,
        int index,
        string name,
        bool isOn = false,
        bool isReachableByBridge = false,
        byte brightness = 0,
        int hue = 0)
    {
        public string Id { get; } = id;
        public int Index { get; } = index;
        public string Name { get; } = name;
        public bool IsOn { get; set; } = isOn;
        public bool IsReachableByBridge { get; } = isReachableByBridge;
        public byte Brightness { get; set; } = brightness;
        public int Hue { get; set; } = hue;
    }
}
