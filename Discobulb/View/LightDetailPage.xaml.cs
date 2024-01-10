using Discobulb.Model;

namespace Discobulb.View;

[QueryProperty(nameof(Light), "Light")]
public partial class LightDetailPage : ContentPage
{
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

	public LightDetailPage()
	{
		InitializeComponent();

		Shell.SetNavBarIsVisible(this, false);

		BindingContext = this;
	}

	private async void GoBack(object? _, EventArgs __)
	{
		await Shell.Current.GoToAsync("..");
	}
}