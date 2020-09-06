using LiteDB;
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
            var currentItems = order.getItems();
            var key = item.getID();

            if (currentItems.ContainsKey(key))
            {
                var currentTotalOrdered = currentItems[key].getTotalOrdered();
                currentItems[key].setTotalOrdered(currentTotalOrdered += item.getTotalOrdered());
                //itemCollection.Update(currentItems[key]);
            }
            else
            {
                currentItems.Add(key, item);
                //itemCollection.Insert(item);
            }
            
            return currentItems;
        }
    }
}
