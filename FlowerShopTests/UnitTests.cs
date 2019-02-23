using NUnit.Framework;
using NSubstitute;
using FlowerShop;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //Arrange
            IOrderDAO orderDAO = Substitute.For<IOrderDAO>();
            IClient client = Substitute.For<IClient>();
            IOrder Order = Substitute.For<IOrder>();
            Order order = new Order(orderDAO, client);

            //Act
            order.Deliver();

            //Assert
            orderDAO.Received().SetDelivered(Arg.Any<IOrder>());
        }
    }
}