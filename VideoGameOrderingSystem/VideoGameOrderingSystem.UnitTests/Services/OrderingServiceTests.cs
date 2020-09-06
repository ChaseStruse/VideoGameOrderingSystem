﻿using NUnit.Framework;
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
            Item item = new Item(1, "Halo", "best game", Categories.FirstPersonShooter, 50.50, 100);
            Order order = new Order();
            order.SetItems(_orderingService.AddItemToOrder(item, order));
            
            Dictionary<int, Item> actualItems = order.getItems();
            int expectedLength = 1;
            int actualLength = actualItems.Count();

            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(item, actualItems[item.getID()]);
        }
    }
}