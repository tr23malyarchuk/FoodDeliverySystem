﻿using Moq;
using Microsoft.EntityFrameworkCore;
using Catalog.DAL.Entities;
using Catalog.DAL.EF;

public class BaseRepositoryUnitTests
{
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

        var repository = new TestBaseRepository(mockContext.Object);
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

        Order expectedOrder = new Order() { OrderId = 1 };
        mockDbSet.Setup(mock => mock
                 .Find(expectedOrder.OrderId))
                 .Returns(expectedOrder);

        var repository = new TestBaseRepository(mockContext.Object);

        //Act
        var actualStreet = repository.Get(expectedOrder.OrderId);

        // Assert
        mockDbSet.Verify(dbSet => dbSet
                 .Find(expectedOrder.OrderId), Times
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

        var repository = new TestBaseRepository(mockContext.Object);
        Order expectedOrder = new Order() { OrderId = 1 };

        mockDbSet.Setup(mock => mock.Find(expectedOrder.OrderId))
                 .Returns(expectedOrder);

        //Act
        repository.Delete(expectedOrder.OrderId);

        // Assert
        mockDbSet.Verify(dbSet => dbSet
                 .Find(expectedOrder.OrderId), Times
                 .Once());

        mockDbSet.Verify(dbSet => dbSet
                 .Remove(expectedOrder), Times
                 .Once());
    }
}
