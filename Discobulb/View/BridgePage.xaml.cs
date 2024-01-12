using Discobulb.Services.AppNavigation;

namespace Discobulb.View;

public partial class BridgePage : ContentPage
{
	private readonly IAppNavigationService _appNavigationService;

	public BridgePage(IAppNavigationService appNavigationService)
	{
		InitializeComponent();
		_appNavigationService = appNavigationService;
	}

	public async void OnConnectClicked(object? sender, EventArgs _)
	{
        Dictionary<string, object> parameters = new() { { "BridgeAddress", addressInput.Text } };

		await _appNavigationService.NavigateAsync("LightsPage", parameters);
    }
}