using Discobulb.View;

namespace Discobulb
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            SetNavBarIsVisible(this, false);

            Routing.RegisterRoute("LightsPage", typeof(LightsPage));
            Routing.RegisterRoute("LightDetailPage", typeof(LightDetailPage));
        }
    }
}
