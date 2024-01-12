using Discobulb.Model;
using Discobulb.Services.AppNavigation;

namespace Discobulb.View;

[QueryProperty(nameof(Light), "Light")]
public partial class LightDetailPage : ContentPage
{
    private readonly IAppNavigationService _appNavigationService;
    private LightModel _light;
	public LightModel Light
	{
		get => _light;
		set
		{
			if (_light != value)
			{
				_light = value;
				OnPropertyChanged();
			}
		}
	}

	public LightDetailPage(IAppNavigationService appNavigationService)
	{
		InitializeComponent();
        _appNavigationService = appNavigationService;

        Shell.SetNavBarIsVisible(this, false);

		BindingContext = this;
	}

	public async void GoBack(object? _, EventArgs __)
	{
		Dictionary<string, object> backParam = new() { { "AlreadyConnected", true } };
		await Shell.Current.GoToAsync("..", backParam);
	}
}