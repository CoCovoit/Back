using CocovoitAPI.Business.Entity;
using Xunit;

namespace CocovoitAPITest.UnitTests.Entity;

public class LocalisationTests
{
    [Fact]
    public void Constructor_SetsPropertiesCorrectly()
    {
        // Arrange
        var adresse = "10 rue des Lilas";
        var longitude = 2.3522;
        var latitude = 48.8566;

        // Act
        var localisation = new Localisation(adresse, longitude, latitude);

        // Assert
        Assert.Equal(adresse, localisation.Adresse);
        Assert.Equal(longitude, localisation.Longitude);
        Assert.Equal(latitude, localisation.Latitude);
    }

    [Fact]
    public void Properties_CanBeModified()
    {
        // Arrange
        var localisation = new Localisation("adresse initiale", 0, 0);

        // Act
        localisation.Id = 42;
        localisation.Adresse = "12 avenue Victor Hugo";
        localisation.Latitude = 43.6;
        localisation.Longitude = 1.44;

        // Assert
        Assert.Equal(42, localisation.Id);
        Assert.Equal("12 avenue Victor Hugo", localisation.Adresse);
        Assert.Equal(43.6, localisation.Latitude);
        Assert.Equal(1.44, localisation.Longitude);
    }

    [Fact]
    public void Adresse_DefaultsToEmptyString()
    {
        // Arrange
        var localisation = new Localisation(string.Empty, 0, 0);

        // Assert
        Assert.Equal(string.Empty, localisation.Adresse);
    }
}
