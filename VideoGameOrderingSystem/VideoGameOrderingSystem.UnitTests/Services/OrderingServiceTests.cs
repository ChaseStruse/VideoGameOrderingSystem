using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoGameOrderingSystem.Data;
using VideoGameOrderingSystem.Data.Models;

namespace VideoGameOrderingSystem.UnitTests.Services
{
    public class OrderingServiceTests
    {
        private OrderingService _orderingService;
        [SetUp]
        public void SetUp()
        {
            _orderingService = new OrderingService();
        }

        [Test]
        public void GivenAnItemAddItemToOrderUpdatesProperly()
        {
            Item item = new Item(1, "Halo", "best game", Categories.FirstPersonShooter, 50.50, 2, 100);
            Order order = new Order();
            order.SetItems(_orderingService.AddItemToOrder(item, order));

            Dictionary<int, Item> actualItems = order.getItems();
            int expectedLength = 1;
            int actualLength = actualItems.Count();

            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(item, actualItems[item.getID()]);
        }

        [Test]
        public void GivenTwoItemsWithSameIdQuantityOrderedUpdatesAppropriately()
        {
            Item item1 = new Item(1, "Halo", "best game", Categories.FirstPersonShooter, 50.50, 2, 100);
            Item item2 = new Item(1, "Halo", "best game", Categories.FirstPersonShooter, 50.50, 8, 100);
            
            Order order = new Order();

            order.SetItems(_orderingService.AddItemToOrder(item1, order));
            order.SetItems(_orderingService.AddItemToOrder(item2, order));

            Dictionary<int, Item> actualItems = order.getItems();

            int expectedLength = 1;
            int actualLength = actualItems.Count();

            int expectedTotalOrdered = 10;
            int actualTotalOrdered = actualItems[item1.getID()].getTotalOrdered();

            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedTotalOrdered, actualTotalOrdered);
        }
    }
}
