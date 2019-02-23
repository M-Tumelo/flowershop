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

       // [Test]
        //public void Test1()
        //{
        //    //Arrange
        //    IOrderDAO orderDAO = Substitute.For<IOrderDAO>();
        //    IClient client = Substitute.For<IClient>();
        //    IOrder Order = Substitute.For<IOrder>();
        //    Order order = new Order(orderDAO, client);

        //    //Act
        //    order.Deliver();

        //    //Assert
        //    orderDAO.Received().SetDelivered(Arg.Any<IOrder>());
        //}
        [Test]
        public void Test2()
        {
            //Arrange
            //IOrderDAO orderDAO = Substitute.For<IOrderDAO>();
            IFlowerDAO flowerDAO = Substitute.For<IFlowerDAO>();
            //IClient client = Substitute.For<IClient>();
            //IOrder Order = Substitute.For<IOrder>();
            Order order = Substitute.For<Order>(Arg.Any<IOrderDAO>(), Arg.Any<IClient>());
            var flower = Substitute.For<Flower>(flowerDAO,"Red",274.99,3);
            var flower1 = Substitute.For<Flower>(flowerDAO, "White Roses", 129.99, 10);
            var flower2 = Substitute.For<Flower>(flowerDAO, "SunFlower", 50, 30);

            //Act
            order.AddFlowers(Arg.Any<Flower>(),Arg.Any<int>());

            //Assert
            Assert.That(order.Price, Is.EqualTo(2));
        }
    }
}