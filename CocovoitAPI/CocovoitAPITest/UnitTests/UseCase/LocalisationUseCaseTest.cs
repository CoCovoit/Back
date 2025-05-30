using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq;
using CocovoitAPI.Business.Entity;
using CocovoitAPI.Application.UseCase;

namespace CocovoitAPITest.UnitTests.UseCase
{
    public class LocalisationUseCaseTests
    {
        private readonly Mock<ILocalisationUseCase> _mockUseCase;

        public LocalisationUseCaseTests()
        {
            _mockUseCase = new Mock<ILocalisationUseCase>();
        }

        [Fact]
        public async Task Create_ShouldReturnCreatedLocalisation()
        {
            // Arrange
            var localisation = new Localisation("1 rue de test", 1.1, 2.2);
            _mockUseCase.Setup(uc => uc.Create(It.IsAny<Localisation>()))
                        .ReturnsAsync((Localisation loc) => loc);

            // Act
            var result = await _mockUseCase.Object.Create(localisation);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("1 rue de test", result.Adresse);
            Assert.Equal(1.1, result.Longitude);
            Assert.Equal(2.2, result.Latitude);
        }

        [Fact]
        public async Task FindAll_ShouldReturnListOfLocalisations()
        {
            // Arrange
            var expected = new List<Localisation>
            {
                new Localisation("A", 1.0, 2.0),
                new Localisation("B", 3.0, 4.0)
            };

            _mockUseCase.Setup(uc => uc.FindAll())
                        .ReturnsAsync(expected);

            // Act
            var result = await _mockUseCase.Object.FindAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task FindById_ShouldReturnCorrectLocalisation()
        {
            // Arrange
            var expected = new Localisation("Adresse ID", 5.5, 6.6) { Id = 10 };

            _mockUseCase.Setup(uc => uc.FindById(10))
                        .ReturnsAsync(expected);

            // Act
            var result = await _mockUseCase.Object.FindById(10);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(10, result.Id);
            Assert.Equal("Adresse ID", result.Adresse);
        }

        [Fact]
        public async Task FindByCoordonnees_ShouldReturnMatchingLocalisation()
        {
            // Arrange
            var expected = new Localisation("Adresse Coord", 9.9, 8.8);

            _mockUseCase.Setup(uc => uc.FindByCoordonnees(9.9, 8.8, "Adresse Coord"))
                        .ReturnsAsync(expected);

            // Act
            var result = await _mockUseCase.Object.FindByCoordonnees(9.9, 8.8, "Adresse Coord");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Adresse Coord", result.Adresse);
            Assert.Equal(9.9, result.Longitude);
            Assert.Equal(8.8, result.Latitude);
        }
    }
}
