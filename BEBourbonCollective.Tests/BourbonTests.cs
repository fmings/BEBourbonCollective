using BEBourbonCollective.Interfaces;
using BEBourbonCollective.Models;
using BEBourbonCollective.Services;
using Moq;

namespace BEBourbonCollective.Tests
{
    public class BourbonTests
    {
        private readonly BourbonService _bourbonService;

        private readonly Mock<IBourbonRepository> _mockBourbonRepository;

        public BourbonTests()
        {
            _mockBourbonRepository = new Mock<IBourbonRepository>();
            _bourbonService = new BourbonService(_mockBourbonRepository.Object);
        }

        [Fact]

        public async Task GetAllBourbonsAsync_ShouldReturnListOfBourbons()
        {
            // Arrange
            var bourbons = new List<Bourbon>
            {
                new Bourbon { Id = 1, UserId=1, DistilleryId=1, Name="Bourbon #1", OpenBottle=true, EmptyBottle=false},
                new Bourbon { Id = 2, UserId=1, DistilleryId=2, Name="Bourbon #2", OpenBottle=false, EmptyBottle=false}
            };

            // Setup
            _mockBourbonRepository.Setup(repo => repo.GetAllBourbonsAsync()).ReturnsAsync(bourbons);

            // Act
            var result = await _bourbonService.GetAllBourbonsAsync();

            // Assert
            _mockBourbonRepository.Verify(repo => repo.GetAllBourbonsAsync(), Times.Once());
            Assert.Equal(bourbons.Count, result.Count);
            Assert.Equal(bourbons[0].Id, result[0].Id);
            Assert.Equal(bourbons[1].Id, result[1].Id);

        }

        [Fact]
        public async Task AddBourbonAsync_ShouldReturnNewBourbonId()
        {
            // Arrange
            var newBourbon = new Bourbon
            {
                Id = 3,
                UserId = 1,
                DistilleryId = 2,
                Name = "Bourbon #3",
                OpenBottle = false,
                EmptyBottle = false
            };

            // Setup
            _mockBourbonRepository
                .Setup(repo => repo.AddBourbonAsync(newBourbon))
                .ReturnsAsync(newBourbon);

            // Act
            var actualBourbon = await _bourbonService.AddBourbonAsync(newBourbon);

            // Assert
            Assert.Equal(newBourbon.Id, actualBourbon.Id);
        }

        [Fact]
        public async Task UpdateSingleBourbonAsync_ShouldReturnUpdatedBourbon_WhenBourbonExists()
        {
            // Arrange
            var updatedBourbon = new Bourbon
            {
                Id = 3,
                UserId = 1,
                DistilleryId = 2,
                Name = "Bourbon #3",
                OpenBottle = true,
                EmptyBottle = false
            };

            // Setup
            _mockBourbonRepository
                .Setup(repo => repo.UpdateSingleBourbonAsync(updatedBourbon.Id, updatedBourbon))
                .ReturnsAsync(updatedBourbon);

            // Act
            var result = await _bourbonService.UpdateSingleBourbonAsync(updatedBourbon.Id, updatedBourbon);

            // Assert
            Assert.Equal(updatedBourbon, result);
        }

        [Fact]
        public async Task DeleteSingleBourbonAsync_ShouldReturnDeletedBourbon_WhenBourbonDeleted()
        {
            // Arrange
            var bourbonId = 1;
            var bourbonToDelete = new Bourbon
            {
                Id = 3,
                UserId = 1,
                DistilleryId = 2,
                Name = "Bourbon #3",
                OpenBottle = true,
                EmptyBottle = false
            };

            // Setup
            _mockBourbonRepository.Setup(repo => repo.DeleteSingleBourbonAsync(bourbonId)).ReturnsAsync(bourbonToDelete);

            // Act
            var result = await _bourbonService.DeleteSingleBourbonAsync(bourbonId);

            // Assert
            Assert.Equal(bourbonToDelete, result);
        }
    }
}