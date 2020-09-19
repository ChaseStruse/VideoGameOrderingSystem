using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using VideoGameOrderingSystem.Data.Models;
using VideoGameOrderingSystem.Data.Services;

namespace VideoGameOrderingSystem
{
    public class OrderingService
    {
        private LiteDatabase database;
        private ILiteCollection<Order> orderCollection;
        private IItemService itemService;

        public OrderingService(LiteDatabase _database)
        {
            database = _database;
            orderCollection = database.GetCollection<Order>("Orders");
            itemService = new ItemService(database);
        }
        public void AddItemToOrder(Order order, Item item, int amountOrdered)
        {
            order.items.Add(item.id, item);
            order.amountOrdered.Add(item.id, amountOrdered);
        }
        public void ValidateItemInventoryAndReduceInventory(Order order)
        {
            foreach (Item item in order.items.Values)
            {
                itemService.ReduceInventory(item, order);
            }
        }
        public void CommitOrderToDatabase(Order order)
        {
            LiteDatabase database = new LiteDatabase(@"VideoGameOrderingSystem/VideoGameOrderingSystem.Data/Database/Main.db");
            try
            {
                if (order.isValid)
                {
                    var orderCollection = database.GetCollection<Order>("Orders");
                    order.fulfillDate = DateTime.UtcNow;
                    orderCollection.Insert(order);
                }
                else
                {
                    Console.WriteLine("Order is not valid, please check prior logs and attempt order again");
                }
            }
            catch
            {
                Console.WriteLine("There was an error please try again");
            }
        }
        
        public Order GetOrder(int key, LiteDatabase database)
        {
            try
            {
                var orderCollection = database.GetCollection<Order>("Orders");
                var result = orderCollection.Query()
                                            .Where(x => x.id == key)
                                            .Select(x => new Order { id = x.id, fulfillDate = x.fulfillDate, items = x.items, amountOrdered = x.amountOrdered, isValid = x.isValid })
                                            .FirstOrDefault();
                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
