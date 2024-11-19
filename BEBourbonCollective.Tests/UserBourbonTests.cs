using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEBourbonCollective.Interfaces;
using BEBourbonCollective.Models;
using BEBourbonCollective.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;

namespace BEBourbonCollective.Tests
{
    public class UserBourbonTests
    {
        private readonly UserBourbonService _userBourbonService;

        private readonly Mock<IUserBourbonRepository> _mockUserBourbonRepository;

        public UserBourbonTests()
        {
            _mockUserBourbonRepository = new Mock<IUserBourbonRepository>();
            _userBourbonService = new UserBourbonService(_mockUserBourbonRepository.Object);
        }

        [Fact]

        public async Task GetAllUserBourbonsAsync_ShouldReturnListOfUserBourbons()
        {
            // Arrange
            var userId = 1;
            var userBourbons = new List<UserBourbon>
            {
                new UserBourbon { Id = 1, UserId=1, BourbonId=1},
                new UserBourbon { Id = 2, UserId=1, BourbonId=2}
            };

            // Setup
            _mockUserBourbonRepository.Setup(repo => repo.GetAllUserBourbonsAsync(userId)).ReturnsAsync(userBourbons);

            // Act
            var result = await _userBourbonService.GetAllUserBourbonsAsync(userId);

            // Assert
            _mockUserBourbonRepository.Verify(repo => repo.GetAllUserBourbonsAsync(userId), Times.Once());
            Assert.Equal(userBourbons.Count, result.Count);
            Assert.Equal(userBourbons[0].Id, result[0].Id);
            Assert.Equal(userBourbons[1].Id, result[1].Id);

        }

        [Fact]
        public async Task AddUserBourbonAsync_ShouldReturnNewUserBourbonId()
        {
            // Arrange
            var newUserBourbon = new UserBourbon
            {
                Id = 6,
                UserId = 1,
                BourbonId = 1
            };

            // Setup
            _mockUserBourbonRepository
                .Setup(repo => repo.AddUserBourbonAsync(newUserBourbon))
                .ReturnsAsync(newUserBourbon);

            // Act
            var actualUserBourbon = await _userBourbonService.AddUserBourbonAsync(newUserBourbon);

            // Assert
            Assert.Equal(newUserBourbon.Id, actualUserBourbon.Id);
        }

        [Fact]
        public async Task UpdateUserBourbonAsync_ShouldReturnUpdatedUserBourbon_WhenUserBourbonExists()
        {
            // Arrange
            var updatedUserBourbon = new UserBourbon
            {
                Id = 6,
                UserId = 2,
                BourbonId = 2
            };

            // Setup
            _mockUserBourbonRepository
                .Setup(repo => repo.UpdateUserBourbonAsync(updatedUserBourbon.Id, updatedUserBourbon))
                .ReturnsAsync(updatedUserBourbon);

            // Act
            var result = await _userBourbonService.UpdateUserBourbonAsync(updatedUserBourbon.Id, updatedUserBourbon);

            // Assert
            Assert.Equal(updatedUserBourbon, result);
        }

        [Fact]
        public async Task DeleteUserBourbonAsync_ShouldReturnNoContent_WhenUserBourbonDeleted()
        {
            // Arrange
            var userBourbonId = 1;
            var userBourbonToDelete = new UserBourbon
            {
                Id = 1,
                UserId = 2,
                BourbonId = 2
            };

            // Setup
            _mockUserBourbonRepository.Setup(repo => repo.DeleteUserBourbonAsync(userBourbonId)).ReturnsAsync(userBourbonToDelete);

            // Act
            var result = await _userBourbonService.DeleteUserBourbonAsync(userBourbonId);

            // Assert
            Assert.Equal(userBourbonToDelete, result);
        }
    }
}
