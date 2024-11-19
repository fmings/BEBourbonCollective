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
    public class TradeRequestTests
    {
        private readonly TradeRequestService _tradeRequestService;

        private readonly Mock<ITradeRequestRepository> _mockTradeRequestRepository;

        public TradeRequestTests()
        {
            _mockTradeRequestRepository = new Mock<ITradeRequestRepository>();
            _tradeRequestService = new TradeRequestService(_mockTradeRequestRepository.Object);
        }

        [Fact]

        public async Task GetAllPendingTradeRequestsByUser_ShouldReturnListOfPendingTradeRequests()
        {
            // Arrange
            var userId = 1;
            var tradeRequests = new List<TradeRequest>
            {
                new TradeRequest { Id = 1, RequestingUserId=1, RequestingBourbonId=1, RequestedFromUserId=2, RequestedFromBourbonId=2, Pending=true, Approved=false},
                new TradeRequest { Id = 2, RequestingUserId=1, RequestingBourbonId=2, RequestedFromUserId=2, RequestedFromBourbonId=2, Pending=false, Approved=true}
            };

            // Setup
            _mockTradeRequestRepository.Setup(repo => repo.GetAllPendingTradeRequestsByUser(userId)).ReturnsAsync(tradeRequests.Where(tr => tr.Pending).ToList());

            // Act
            var result = await _tradeRequestService.GetAllPendingTradeRequestsByUser(userId);

            // Assert
            _mockTradeRequestRepository.Verify(repo => repo.GetAllPendingTradeRequestsByUser(userId), Times.Once());
            Assert.NotNull(result);
            Assert.All(result, tr => Assert.True(tr.Pending, "All trade requests should be pending."));
            Assert.Equal(1, result.Count);
            Assert.Equal(1, result[0].Id);
        }

        [Fact]
        public async Task AddTradeRequestAsync_ShouldReturnNewTradeRequestId()
        {
            // Arrange
            var newTradeRequest = new TradeRequest
            {
                Id = 3, 
                RequestingUserId=1, 
                RequestingBourbonId=1, 
                RequestedFromUserId=2, 
                RequestedFromBourbonId=4, 
                Pending=true, 
                Approved=false
            };

            // Setup
            _mockTradeRequestRepository
                .Setup(repo => repo.AddTradeRequestAsync(newTradeRequest))
                .ReturnsAsync(newTradeRequest);

            // Act
            var actualTradeRequest = await _tradeRequestService.AddTradeRequestAsync(newTradeRequest);

            // Assert
            Assert.Equal(newTradeRequest.Id, actualTradeRequest.Id);
        }

        [Fact]
        public async Task UpdateTradeRequestAsync_ShouldReturnUpdatedTradeRequest_WhenTradeRequestExists()
        {
            // Arrange
            var updatedTradeRequest = new TradeRequest
            {
                Id = 3,
                RequestingUserId = 1,
                RequestingBourbonId = 1,
                RequestedFromUserId = 2,
                RequestedFromBourbonId = 4,
                Pending = false,
                Approved = true
            };

            // Setup
            _mockTradeRequestRepository
                .Setup(repo => repo.UpdateTradeRequestAsync(updatedTradeRequest.Id, updatedTradeRequest))
                .ReturnsAsync(updatedTradeRequest);

            // Act
            var result = await _tradeRequestService.UpdateTradeRequestAsync(updatedTradeRequest.Id, updatedTradeRequest);

            // Assert
            Assert.Equal(updatedTradeRequest, result);
        }

        [Fact]
        public async Task DeleteTradeRequestAsync_ShouldReturnDeletedTradeRequest_WhenUserBourbonDeleted()
        {
            // Arrange
            var tradeRequestId = 1;
            var tradeRequestToDelete = new TradeRequest
            {
                Id = 1,
                RequestingUserId = 1,
                RequestingBourbonId = 1,
                RequestedFromUserId = 2,
                RequestedFromBourbonId = 4,
                Pending = false,
                Approved = true
            };

            // Setup
            _mockTradeRequestRepository.Setup(repo => repo.DeleteTradeRequestAsync(tradeRequestId)).ReturnsAsync(tradeRequestToDelete);

            // Act
            var result = await _tradeRequestService.DeleteTradeRequestAsync(tradeRequestId);

            // Assert
            Assert.Equal(tradeRequestToDelete, result);
        }
    }
}
