using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShop
{
    public class Order : IOrder, IIdentified
    {
        private List<Flower> flowers;
        private bool isDelivered = false;
        public int Id { get; }
        private IOrderDAO Dao;
        // should apply a 20% mark-up to each flower.
        public double Price
        {
            get
            {
                double price = 0;
                for (int i = 0; i < flowers.Count; i++)
                {
                    price += flowers[i].Cost+(flowers[i].Cost * 0.20);
                }
                return price;
            }
        }

        public double Profit
        {
            get
            {
                return 0;
            }
        }

        public IReadOnlyList<IFlower> Ordered
        {
            get
            {
                return flowers.AsReadOnly();
            }
        }

        public IClient Client { get; private set; }

        public Order(IOrderDAO dao, IClient client)
        {
            Dao = dao;
            Id = dao.AddOrder(client);
        }

        // used when we already have an order with an Id.
        public Order(IOrderDAO dao, IClient client, bool isDelivered = false)
        {
            this.flowers = new List<Flower>();
            this.isDelivered = isDelivered;
            Client = client;
            Id = dao.AddOrder(client);
        }

        public void AddFlowers(IFlower flower, int n)
        {
            
        }

        public void Deliver()
        {
            Order order = new Order(this.Dao, this.Client, true);
            Dao.SetDelivered(order);
        }
    }
}
