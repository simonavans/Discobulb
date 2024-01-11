using CommunityToolkit.Mvvm.ComponentModel;

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
