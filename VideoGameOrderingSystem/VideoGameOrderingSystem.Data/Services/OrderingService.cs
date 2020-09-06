using System;
using System.Collections.Generic;
using System.Text;
using VideoGameOrderingSystem.Data.Models;

namespace VideoGameOrderingSystem
{
    public class OrderingService
    {
        public Dictionary<int, Item> AddItemToOrder(Item item, Order order)
        {
            var items = order.getItems();
            items.Add(item.getID(), item);
            return items;
        }
    }
}
