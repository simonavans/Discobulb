using Discobulb.Model;
using Discobulb.Services.Hue;
using Discobulb.ViewModel;
using Moq;

namespace DiscobulbTest.ViewModels
{
    public class LightsPageViewModelTest
    {
        private static readonly LightModel TestLight = new("testId1", "testLight1", false, 5, 5, "testLamp", "testModel1");
        private static readonly byte TestBrightness = 10;
        private static readonly ushort TestHue = 10;

        // Should call equivalent interface method
        [Fact]
        public async void ConnectToBridge_Should_Call_Equivalent_Interface_Method()
        {
            // Arrange
            var mockService = new Mock<IHueService>();
            var sut = new LightsPageViewModel(mockService.Object);

            var bridgeAddress = "127.0.0.1";
            var applicationName = "Discobulb";
            var deviceName = "TestDevice";

            // Act
            await sut.ConnectToBridge(bridgeAddress, applicationName, deviceName);

            // Assert
            mockService.Verify(service => service.ConnectToBridge(bridgeAddress, applicationName, deviceName), Times.Once());
        }

        [Fact]
        public async void LoadLightsAsync_Should_Call_Equivalent_Interface_Method()
        {
            // Arrange
            var mockService = new Mock<IHueService>();
            var sut = new LightsPageViewModel(mockService.Object);

            // Act
            try
            {
                await sut.LoadLightsAsync();
            }
            catch (NullReferenceException)
            {
                // Ignore, the mock service will be unable to return a list of lights
            }

            // Assert
            mockService.Verify(service => service.GetLightsAsync(), Times.Once());
        }

        [Fact]
        public async void SetOnAsync_Should_Call_Equivalent_Interface_Method()
        {
            // Arrange
            var mockService = new Mock<IHueService>();
            var sut = new LightsPageViewModel(mockService.Object);

            // Act
            await sut.SetOnAsync(true, TestLight);

            // Assert
            mockService.Verify(service => service.SetOnAsync(true, TestLight), Times.Once());
        }

        [Fact]
        public async void SetBrightnessAsync_Should_Call_Equivalent_Interface_Method()
        {
            // Arrange
            var mockService = new Mock<IHueService>();
            var sut = new LightsPageViewModel(mockService.Object);

            // Act
            await sut.SetBrightnessAsync(TestBrightness, TestLight);

            // Assert
            mockService.Verify(service => service.SetBrightnessAsync(TestBrightness, TestLight), Times.Once());
        }

        [Fact]
        public async void SetHueAsync_Should_Call_Equivalent_Interface_Method()
        {
            // Arrange
            var mockService = new Mock<IHueService>();
            var sut = new LightsPageViewModel(mockService.Object);

            // Act
            await sut.SetHueAsync(TestHue, TestLight);

            // Assert
            mockService.Verify(service => service.SetHueAsync(TestHue, TestLight), Times.Once());
        }

        // Should update light model
        [Fact]
        public async void SetOnAsync_Should_Update_LightModel()
        {
            // Arrange
            var mockService = new Mock<IHueService>();
            var sut = new LightsPageViewModel(mockService.Object);

            // Act
            await sut.SetOnAsync(true, TestLight);

            // Assert
            Assert.True(TestLight.On);

            // Act
            await sut.SetOnAsync(false, TestLight);

            // Assert
            Assert.False(TestLight.On);
        }

        [Fact]
        public async void SetBrightnessAsync_Should_Update_LightModel()
        {
            // Arrange
            var mockService = new Mock<IHueService>();
            var sut = new LightsPageViewModel(mockService.Object);

            // Act
            await sut.SetBrightnessAsync(TestBrightness, TestLight);

            // Assert
            Assert.Equal(TestBrightness, TestLight.Brightness);
        }

        [Fact]
        public async void SetHueAsync_Should_Update_LightModel()
        {
            // Arrange
            var mockService = new Mock<IHueService>();
            var sut = new LightsPageViewModel(mockService.Object);

            // Act
            await sut.SetHueAsync(TestHue, TestLight);

            // Assert
            Assert.Equal(TestHue, TestLight.Hue);
        }

        // Test SetLightSelected
        [Fact]
        public void SetLightSelected_Should_Add_Selected_Light()
        {
            // Arrange
            var mockService = new Mock<IHueService>();
            var sut = new LightsPageViewModel(mockService.Object);

            // Act
            sut.SetLightSelected(true, TestLight);

            // Assert
            Assert.Contains(TestLight, sut.SelectedLights);
        }

        [Fact]
        public void SetLightSelected_Should_Not_Add_Unselected_Light()
        {
            // Arrange
            var mockService = new Mock<IHueService>();
            var sut = new LightsPageViewModel(mockService.Object);

            // Act
            sut.SetLightSelected(false, TestLight);

            // Assert
            Assert.Empty(sut.SelectedLights);
        }

        [Fact]
        public void SetLightSelected_Should_Remove_Unselected_Light()
        {
            // Arrange
            var mockService = new Mock<IHueService>();
            var sut = new LightsPageViewModel(mockService.Object);

            // Act
            sut.SetLightSelected(true, TestLight);
            sut.SetLightSelected(false, TestLight);

            // Assert
            Assert.DoesNotContain(TestLight, sut.SelectedLights);
        }

        [Fact]
        public void SetLightSelected_Should_Not_Add_Light_If_Already_Contained()
        {
            // Arrange
            var mockService = new Mock<IHueService>();
            var sut = new LightsPageViewModel(mockService.Object);

            // Act
            sut.SetLightSelected(true, TestLight);
            sut.SetLightSelected(true, TestLight);

            // Assert
            Assert.Single(sut.SelectedLights);
        }
    }
}
