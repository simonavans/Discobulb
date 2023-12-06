using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discobulb.Model
{
    public class Bulb
    {
        public string Name { get; set; }
        public bool IsOn { get; set; }
        public bool IsReachableByBridge { get; set; }
        public byte Brightness { get; set; }
        public int Hue { get; set; }
    }
}
