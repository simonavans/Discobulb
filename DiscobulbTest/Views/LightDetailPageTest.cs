using Discobulb.Services.AppNavigation;
using Discobulb.View;
using Moq;

namespace DiscobulbTest.Views
{
    public class LightDetailPageTest
    {
        [Fact]
        public void GoBack_Should_Navigate_To_Previous_Page()
        {
            // Arrange
            var mockNavigationService = new Mock<IAppNavigationService>();
            var sut = new LightDetailPage(mockNavigationService.Object);

            // Act
            sut.GoBack(null, null);

            // Assert
            mockNavigationService.Verify(x => x.NavigateAsync("..", It.IsAny<Dictionary<string, object>>()), Times.Once);
        }
    }
}
