using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discobulb.Model
{
    public partial class LightModel(string id, string name, bool on, byte brightness, ushort hue, string type, string modelId) : ObservableObject
    {
        [ObservableProperty]
        private string _id = id;

        [ObservableProperty]
        private string _name = name;

        [ObservableProperty]
        private bool _on = on;

        [ObservableProperty]
        private byte _brightness = brightness;

        [ObservableProperty]
        private ushort _hue = hue;

        [ObservableProperty]
        private string _type = type;

        [ObservableProperty]
        private string _modelId = modelId;
    }
}
