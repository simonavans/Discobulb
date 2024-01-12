using Discobulb.Services.AppNavigation;
using Discobulb.View;
using Moq;

namespace DiscobulbTest.Views
{
    public class BridgePageTest
    {
        [Fact]
        public void OnConnectClicked_Should_Navigate_To_LightsPage()
        {
            // Arrange
            var mockNavigationService = new Mock<IAppNavigationService>();
            var sut = new BridgePage(mockNavigationService.Object);

            // Act
            sut.OnConnectClicked(null, null);

            // Assert
            mockNavigationService.Verify(x => x.NavigateAsync("LightsPage", It.IsAny<Dictionary<string, object>>()), Times.Once);
        }
    }
}
