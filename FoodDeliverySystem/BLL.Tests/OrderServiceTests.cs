using Catalog.CCL.Security;
using Catalog.DAL.UnitOfWork;
using Moq;
using Catalog.BLL.Services.Impl;
using Xunit;
using Catalog.DAL.Repositories.Interfaces;

namespace BLL.Tests
{
    public class OrderServiceTests
    {
        [Fact]
        // throws an ArgumentNullException when a null IUnitOfWork is passed.
        public void Constr_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act, Assert
            Assert.Throws<ArgumentNullException>(
                () => new OrderService(nullUnitOfWork)
            );
        }

        [Fact]
        // throws an InvalidOperationException when no user is set in the security context.
        public void GetOrders_NoUserInContext_ThrowInvalidOperationException()
        {
            // Arrange
            SecurityContext.SetUser(null); // No user in context
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var orderService = new OrderService(mockUnitOfWork.Object);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => orderService.GetOrders(1));
        }

        [Fact]
        // mocks the data repository and the user context to verify the correct mapping
        public void GetOrders_OrderFromDAL_CorrectMappingToOrderDTO()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var expectedOrder = new Catalog.DAL.Entities.Order()
            {
                OrderId = 1,
                ClientId = 1,
                TotalAmount = 100.0,
                Status = "Completed",
                FoodDeliverySystemId = 1
            };

            var mockOrderRepository = new Mock<IOrderRepository>();
            mockOrderRepository
                .Setup(repo => repo.Where(It.IsAny<Func<Catalog.DAL.Entities.Order, bool>>()))
                .Returns(new List<Catalog.DAL.Entities.Order> { expectedOrder });

            mockUnitOfWork.Setup(uow => uow.Orders).Returns(mockOrderRepository.Object);

            var mockUser = new Catalog.Security.Identity.User(1, "user1", 1);
            SecurityContext.SetUser(mockUser);

            var orderService = new OrderService(mockUnitOfWork.Object);

            // Act
            var actualOrderDto = orderService.GetOrders(1).First();

            // Assert
            Assert.True(
                actualOrderDto.OrderId == 1
                && actualOrderDto.ClientId == 1
                && actualOrderDto.TotalAmount == 100.0
                && actualOrderDto.Status == "Completed"
            );
        }
    }
}