using Moq;
using Microsoft.EntityFrameworkCore;
using Catalog.DAL.Entities;
using Catalog.DAL.EF;
using Catalog.DAL.Repositories.Impl;

public class OrderRepositoryTests
{
    private Mock<FoodDeliverySystemContext> _mockContext;
    private Mock<DbSet<Order>> _mockDbSet;
    private OrderRepository _orderRepository;

    public OrderRepositoryTests()
    {
        _mockContext = new Mock<FoodDeliverySystemContext>();
        _mockDbSet = new Mock<DbSet<Order>>();
        _mockContext.Setup(c => c.Set<Order>()).Returns(_mockDbSet.Object);
    }

    [Fact]
    public void Create_InputOrderInstance_CalledAddMethodOfDBSetWithOrderInstance()
    {
        // Arrange
        DbContextOptions opt = new DbContextOptionsBuilder<FoodDeliverySystemContext>().Options;

        var mockContext = new Mock<FoodDeliverySystemContext>(opt);
        var mockDbSet = new Mock<DbSet<Order>>();

        mockContext
                  .Setup(context => context.Set<Order>())
                  .Returns(mockDbSet.Object);

        var repository = new TestOrderRepository(mockContext.Object);
        Order expectedOrder = new Mock<Order>().Object;

        //Act
        repository.Create(expectedOrder);

        // Assert
        mockDbSet.Verify(dbSet => dbSet
                 .Add(expectedOrder), Times
                 .Once());
    }

    [Fact]
    public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
    {
        // Arrange
        DbContextOptions opt = new DbContextOptionsBuilder<FoodDeliverySystemContext>().Options;

        var mockContext = new Mock<FoodDeliverySystemContext>(opt);
        var mockDbSet = new Mock<DbSet<Order>>();

        mockContext
                 .Setup(context => context.Set<Order>())
                 .Returns(mockDbSet.Object);

        Order expectedOrder = new Order() { Id = 1 };
        mockDbSet.Setup(mock => mock
                 .Find(expectedOrder.Id))
                 .Returns(expectedOrder);

        var repository = new TestOrderRepository(mockContext.Object);

        //Act
        var actualStreet = repository.Get(expectedOrder.Id);

        // Assert
        mockDbSet.Verify(dbSet => dbSet
                 .Find(expectedOrder.Id), Times
                 .Once());

        Assert.Equal(expectedOrder, actualStreet);

    }

    [Fact]
    public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
    {
        // Arrange
        DbContextOptions opt = new DbContextOptionsBuilder<FoodDeliverySystemContext>().Options;

        var mockContext = new Mock<FoodDeliverySystemContext>(opt);
        var mockDbSet = new Mock<DbSet<Order>>();

        mockContext
                 .Setup(context => context
                 .Set<Order>())
                 .Returns(mockDbSet.Object);

        var repository = new TestOrderRepository(mockContext.Object);
        Order expectedOrder = new Order() { Id = 1 };

        mockDbSet.Setup(mock => mock.Find(expectedOrder.Id))
                 .Returns(expectedOrder);

        //Act
        repository.Delete(expectedOrder.Id);

        // Assert
        mockDbSet.Verify(dbSet => dbSet
                 .Find(expectedOrder.Id), Times
                 .Once());

        mockDbSet.Verify(dbSet => dbSet
                 .Remove(expectedOrder), Times
                 .Once());
    }
}
