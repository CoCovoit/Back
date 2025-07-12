using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using CocovoitAPI.Business.Entity;
using CocovoitAPI.Business.Repository;
using System;

namespace CocovoitAPITest.IntegrationTests.Repository
{
    public class LocalisationRepositoryTests
    {
        private readonly ApplicationDbContext _context;
        private readonly LocalisationRepository _repository;

        public LocalisationRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // 🔁 Important pour éviter cache entre tests
            .Options;

            _context = new ApplicationDbContext(options);
            _context.Database.EnsureDeleted(); // Nettoyage (souvent redondant avec Guid)
            _context.Database.EnsureCreated(); // Création

            _repository = new LocalisationRepository(_context);
        }

        [Fact]
        public async Task Create_ShouldReturnCreatedLocalisation()
        {
            // Arrange
            var localisation = new Localisation("1 rue de test", 1.1, 2.2);

            // Act
            var result = await _repository.Create(localisation);

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
            await _repository.Create(new Localisation("A", 1.0, 2.0));
            await _repository.Create(new Localisation("B", 3.0, 4.0));

            // Act
            var result = await _repository.FindAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void FindByCoordonnees_ShouldReturnCorrectLocalisation()
        {
            // Arrange
            var localisation = new Localisation("Coordonnée A", 10.0, 20.0);
            _context.Localisations.Add(localisation);
            _context.SaveChanges();

            // Act
            var result = _repository.FindByCoordonnees(10.0, 20.0);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Coordonnée A", result.Adresse);
        }

        [Fact]
        public async Task FindById_ShouldReturnLocalisation_WhenExists()
        {
            // Arrange
            var loc = new Localisation("Adresse", 1.1, 2.2);
            _context.Localisations.Add(loc);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.FindById(loc.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(loc.Id, result?.Id);
        }

        [Fact]
        public async Task FindById_ShouldReturnNull_WhenNotFound()
        {
            // Act
            var result = await _repository.FindById(999);

            // Assert
            Assert.Null(result);
        }
    }
}
