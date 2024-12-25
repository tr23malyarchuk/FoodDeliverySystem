using Moq;
using Microsoft.EntityFrameworkCore;
using Catalog.DAL.Entities;
using Catalog.DAL.EF;
using Catalog.DAL.Repositories.Impl;
using Catalog.DAL.Repositories.Interfaces;

public class OrderRepositoryUnitTests
{
    // OrderRepository storage methods testing with pagination 
    [Fact]
    public void GetOrdersByClientId_ValidClientId_ReturnsCorrectOrders()
    {
        // Arrange
        var mockRepo = new Mock<IOrderRepository>();
        mockRepo.Setup(r => r.GetOrdersByClientId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new List<Order>
                {
                    new Order { OrderId = 1, ClientId = 1 },
                    new Order { OrderId = 2, ClientId = 1 }
                });

        // Act
        var result = mockRepo.Object.GetOrdersByClientId(1, 1, 10);  // Example: pageNumber = 1, pageSize = 10

        // Assert
        Assert.Equal(2, result.Count());
        Assert.All(result, order => Assert.Equal(1, order.ClientId));
    }

    [Fact]
    public void GetOrdersByStatus_ValidStatus_ReturnsCorrectOrders()
    {
        // Arrange
        var mockRepo = new Mock<IOrderRepository>();
        mockRepo.Setup(repo => repo.GetOrdersByStatus("Completed", It.IsAny<int>(), It.IsAny<int>()))
                      .Returns(new List<Order>
                      {
                        new Order { OrderId = 1, Status = "Completed" },
                        new Order { OrderId = 2, Status = "Completed" }
                      });

        // Act
        var result = mockRepo.Object.GetOrdersByStatus("Completed", 1, 10);  // Example: pageNumber = 1, pageSize = 10

        // Assert
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public void GetOrdersByDateRange_ValidRange_ReturnsCorrectOrders()
    {
        // Arrange
        var mockRepo = new Mock<IOrderRepository>();
        mockRepo.Setup(r => r.GetOrdersByDateRange(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new List<Order>
                {
                    new Order { OrderId = 1, OrderDate = new DateTime(2023, 12, 1) },
                    new Order { OrderId = 2, OrderDate = new DateTime(2023, 12, 15) }
                });

        // Act
        var result = mockRepo.Object.GetOrdersByDateRange(new DateTime(2023, 12, 1), new DateTime(2023, 12, 31), 1, 10);  // Example: pageNumber = 1, pageSize = 10

        // Assert
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public void GetOrdersByTotalAmountGreaterThan_InputIsValid_ReturnsCorrectOrders()
    {
        // Arrange
        var orders = new List<Order>
        {
            new Order { OrderId = 1, TotalAmount = 150 },
            new Order { OrderId = 2, TotalAmount = 50 }
        };

        var mockRepo = new Mock<IOrderRepository>();
        mockRepo.Setup(r => r.GetOrdersByTotalAmountGreaterThan(100, It.IsAny<int>(), It.IsAny<int>()))
                .Returns(orders.Where(o => o.TotalAmount > 100));

        // Act
        var result = mockRepo.Object.GetOrdersByTotalAmountGreaterThan(100, 1, 10);  // Example: pageNumber = 1, pageSize = 10

        // Assert
        Assert.Single(result);
    }
}
