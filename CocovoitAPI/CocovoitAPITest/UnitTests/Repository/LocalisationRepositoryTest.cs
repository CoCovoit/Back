using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq;
using CocovoitAPI.Business.Entity;
using CocovoitAPI.Business.Repository;

namespace CocovoitAPITest.UnitTests.Repository
{
    public class LocalisationRepositoryTests
    {
        private readonly Mock<ILocalisationRepository> _mockRepo;

        public LocalisationRepositoryTests()
        {
            _mockRepo = new Mock<ILocalisationRepository>();
        }

        [Fact]
        public async Task Create_ShouldReturnCreatedLocalisation()
        {
            // Arrange
            var localisation = new Localisation("1 rue de test", 1.1, 2.2);
            _mockRepo.Setup(repo => repo.Create(It.IsAny<Localisation>()))
                     .ReturnsAsync((Localisation loc) => loc);

            // Act
            var result = await _mockRepo.Object.Create(localisation);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(localisation.Adresse, result.Adresse);
            Assert.Equal(localisation.Longitude, result.Longitude);
            Assert.Equal(localisation.Latitude, result.Latitude);
        }

        [Fact]
        public async Task FindAll_ShouldReturnListOfLocalisations()
        {
            // Arrange
            var expectedList = new List<Localisation>
            {
                new Localisation("A", 1.0, 2.0),
                new Localisation("B", 3.0, 4.0)
            };

            _mockRepo.Setup(repo => repo.FindAll()).ReturnsAsync(expectedList);

            // Act
            var result = await _mockRepo.Object.FindAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void FindByCoordonnees_ShouldReturnCorrectLocalisation()
        {
            // Arrange
            var expected = new Localisation("Coordonnée A", 10.0, 20.0);

            _mockRepo.Setup(repo => repo.FindByCoordonnees(10.0, 20.0))
                     .Returns(expected);

            // Act
            var result = _mockRepo.Object.FindByCoordonnees(10.0, 20.0);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Coordonnée A", result.Adresse);
        }

        [Fact]
        public async Task FindById_ShouldReturnLocalisation_WhenExists()
        {
            // Arrange
            var expected = new Localisation("Adresse", 1.1, 2.2) { Id = 42 };

            _mockRepo.Setup(repo => repo.FindById(42))
                     .ReturnsAsync(expected);

            // Act
            var result = await _mockRepo.Object.FindById(42);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(42, result?.Id);
        }

        [Fact]
        public async Task FindById_ShouldReturnNull_WhenNotFound()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.FindById(999)).ReturnsAsync((Localisation?)null);

            // Act
            var result = await _mockRepo.Object.FindById(999);

            // Assert
            Assert.Null(result);
        }
    }
}
