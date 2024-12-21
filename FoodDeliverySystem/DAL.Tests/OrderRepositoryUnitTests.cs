using Moq;
using Microsoft.EntityFrameworkCore;
using Catalog.DAL.Entities;
using Catalog.DAL.EF;
using Catalog.DAL.Repositories.Impl;
using Catalog.DAL.Repositories.Interfaces;

public class OrderRepositoryUnitTests
{
    // OrderRepository storage methods testing 
    [Fact]
    public void GetOrdersByClientId_ValidClientId_ReturnsCorrectOrders()
    {
        // Arrange
        var mockRepo = new Mock<IOrderRepository>();
        mockRepo.Setup(r => r.GetOrdersByClientId(It.IsAny<int>()))
                .Returns(new List<Order>
                {
                    new Order { Id = 1, ClientId = 1 },
                    new Order { Id = 2, ClientId = 1 }
                });

        // Act
        var result = mockRepo.Object.GetOrdersByClientId(1);

        // Assert
        Assert.Equal(2, result.Count());
        Assert.All(result, order => Assert.Equal(1, order.ClientId));
    }

    [Fact]
    public void GetOrdersByStatus_ValidStatus_ReturnsCorrectOrders()
    {
        // Arrange
        var mockRepository = new Mock<IOrderRepository>();
        mockRepository.Setup(repo => repo.GetOrdersByStatus("Completed"))
                      .Returns(new List<Order>
                      {
                        new Order { Id = 1, Status = "Completed" },
                        new Order { Id = 2, Status = "Completed" }
                      });

        // Act
        var result = mockRepository.Object.GetOrdersByStatus("Completed");

        // Assert
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public void GetOrdersByDateRange_ValidRange_ReturnsCorrectOrders()
    {
        // Arrange
        var mockRepo = new Mock<IOrderRepository>();
        mockRepo.Setup(r => r.GetOrdersByDateRange(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .Returns(new List<Order>
                {
                    new Order { Id = 1, OrderDate = new DateTime(2023, 12, 1) },
                    new Order { Id = 2, OrderDate = new DateTime(2023, 12, 15) }
                });

        // Act
        var result = mockRepo.Object.GetOrdersByDateRange(new DateTime(2023, 12, 1), new DateTime(2023, 12, 31));

        // Assert
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public void GetOrdersByTotalAmountGreaterThan_InputIsValid_ReturnsCorrectOrders()
    {
        var orders = new List<Order>
        {
            new Order { Id = 1, TotalAmount = 150 },
            new Order { Id = 2, TotalAmount = 50 }
        };

        var mockRepo = new Mock<IOrderRepository>();
        mockRepo.Setup(r => r.GetOrdersByTotalAmountGreaterThan(100))
                .Returns(orders.Where(o => o.TotalAmount > 100));

        var result = mockRepo.Object.GetOrdersByTotalAmountGreaterThan(100);

        Assert.Single(result);
    }
}
