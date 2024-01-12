namespace Discobulb.Services.AppNavigation
{
    internal class AppNavigationService : IAppNavigationService
    {
        public async Task NavigateAsync(string route)
        {
            await Shell.Current.GoToAsync(route);
        }

        public async Task NavigateAsync(string route, Dictionary<string, object> parameters)
        {
            await Shell.Current.GoToAsync(route, parameters);
        }
    }
}
