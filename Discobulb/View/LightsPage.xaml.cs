using Discobulb.ViewModel;
using Discobulb.Model;

namespace Discobulb.View
{
    [QueryProperty(nameof(BridgeAddress), "BridgeAddress"), QueryProperty(nameof(AlreadyConnected), "AlreadyConnected")]
    public partial class LightsPage : ContentPage
    {
        private readonly LightsPageViewModel _viewModel;

        public string BridgeAddress { get; set; }
        public bool AlreadyConnected { get; set; } = false;

        public LightsPage(LightsPageViewModel viewModel)
        {
            InitializeComponent();

            Shell.SetNavBarIsVisible(this, false);

            _viewModel = viewModel;
            BindingContext = viewModel;
        }

        protected async override void OnAppearing()
        {
            loadingView.IsVisible = true;
            loadedView.IsVisible = false;
            
            if (!AlreadyConnected)
            {
                while (!await _viewModel.ConnectToBridge(BridgeAddress, "discobulb", "discobulb"))
                {
                    await Task.Delay(1000);
                }
            }

            loadingView.IsVisible = false;
            loadedView.IsVisible = true;

            await _viewModel.LoadLightsAsync();
        }

        // TODO
        private async void OnRefreshing(object? sender, EventArgs e)
        {
            await _viewModel.LoadLightsAsync();
        }

        private async void SetOn(object? sender, CheckedChangedEventArgs _)
        {
            if (sender is CheckBox checkBox && checkBox.BindingContext is LightModel light)
            {
                if (!await _viewModel.SetOnAsync(light.On, light))
                    await Shell.Current.DisplayAlert("Error", "An error occurred by setting this light property.", "OK");
            }
        }

        private async void SetBrightness(object? sender, EventArgs _)
        {
            if (sender is Slider slider && slider.BindingContext is LightModel light)
            {
                if (!await _viewModel.SetBrightnessAsync(light.Brightness, light))
                    await Shell.Current.DisplayAlert("Error", "An error occurred by setting this light property.", "OK");
            }
        }

        private async void SetHue(object? sender, EventArgs _)
        {
            if (sender is Slider slider && slider.BindingContext is LightModel light)
            {
                if (!await _viewModel.SetHueAsync(light.Hue, light))
                    await Shell.Current.DisplayAlert("Error", "An error occurred by setting this light property.", "OK");
            }
        }

        private void SetSelected(object? sender, CheckedChangedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.BindingContext is LightModel light)
                _viewModel.SetLightSelected(e.Value, light);
        }

        private async void OnLightTapped(object sender, EventArgs e)
        {
            if (sender is Border border && border.BindingContext is LightModel light)
            {
                Dictionary<string, object> param = new() { { "Light", light } };

                await Shell.Current.GoToAsync("LightDetailPage", param);
            }
        }
    }
}
