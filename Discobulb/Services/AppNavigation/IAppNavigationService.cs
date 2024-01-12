namespace Discobulb.Services.AppNavigation
{
    public interface IAppNavigationService
    {
        Task NavigateAsync(string route);
        Task NavigateAsync(string route, Dictionary<string, object> parameters);
    }
}
