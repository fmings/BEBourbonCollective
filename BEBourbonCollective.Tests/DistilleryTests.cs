using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEBourbonCollective.Interfaces;
using BEBourbonCollective.Models;
using BEBourbonCollective.Services;
using Moq;

namespace BEBourbonCollective.Tests
{
    public class DistilleryTests
    {
        private readonly DistilleryService _distilleryService;

        private readonly Mock<IDistilleryRepository> _mockDistilleryRepository;

        public DistilleryTests()
        {
            _mockDistilleryRepository = new Mock<IDistilleryRepository>();
            _distilleryService = new DistilleryService(_mockDistilleryRepository.Object);
        }

        [Fact]
        public async Task DeleteSingleDistilleryAsync_ShouldReturnDeletedDistillery_WhenDistilleryDeleted()
        {
            // Arrange
            var distilleryId = 1;
            var distilleryToDelete = new Distillery
            {
                Id = 1,
                Name = "Distillery #1",
                City = "Frankfort",
                State = "Kentucky",
            };

            // Setup
            _mockDistilleryRepository.Setup(repo => repo.DeleteSingleDistilleryAsync(distilleryId)).ReturnsAsync(distilleryToDelete);

            // Act
            var result = await _distilleryService.DeleteSingleDistilleryAsync(distilleryId);

            // Assert
            Assert.Equal(distilleryToDelete, result);
        }
    }
}
