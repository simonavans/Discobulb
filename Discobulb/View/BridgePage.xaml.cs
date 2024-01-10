namespace Discobulb.View;

public partial class BridgePage : ContentPage
{
	public BridgePage()
	{
		InitializeComponent();
	}

	private async void OnConnectClicked(object? sender, EventArgs _)
	{
        Dictionary<string, object> parameters = new() { { "BridgeAddress", addressInput.Text } };

        await Shell.Current.GoToAsync("LightsPage", parameters);
    }
}