using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discobulb.Model
{
    public partial class BridgeModel(string name, string ipAddress) : ObservableObject
    {
        [ObservableProperty]
        private string _name = name;
        [ObservableProperty]
        private string _ipAddress = ipAddress;
    }
}
