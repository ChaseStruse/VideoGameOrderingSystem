using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using VideoGameOrderingSystem.Data.Database;
using VideoGameOrderingSystem.Data.Models;

namespace VideoGameOrderingSystem.Data.Services
{
    public interface IItemService
    {
        void AddItemToDatabase(Item item);
        Item GetItem(int key);
        void AddInventory(int key, int amountToAdd);
        void UpdateTotalInventoryAfterReduction(Item item, int amountToReduce);
        void CheckItemHasEnoughInventory(Item item, int amountToReduce);
        void ReduceInventory(Item item, Order order);
    }
    public class ItemService : IItemService
    {
        private LiteDatabase database;
        private ILiteCollection<Item> itemCollection;

        public ItemService(LiteDatabase _database)
        {
            database = _database;
            itemCollection = database.GetCollection<Item>("Items");
        }

        public bool AddItemToDatabase(Item item)
        {
            var itemAdded = false;

            if (GetItem(item.id) == null)
            {
                itemCollection.Insert(item);
                itemAdded = true;
            }

            return itemAdded;
        }

        public Item GetItem(int key)
        {
            try
            {
                var itemCollection = database.GetCollection<Item>("Items");
                var result = itemCollection.Query()
                                            .Where(x => x.id == key)
                                            .Select(x => new Item { id = x.id, name = x.name, description = x.description, category = x.category, price = x.price, totalInventory = x.totalInventory })
                                            .FirstOrDefault();
                return result;
            }
            catch
            {
                return null;
            }
        }

        public void AddInventory(int key, int amountToAdd)
        {
            try
            {
                var itemCollection = database.GetCollection<Item>("Items");
                var item = GetItem(key);

                item.totalInventory += amountToAdd;
                itemCollection.Update(item);
            }
            catch
            {
                Console.WriteLine("Could not find item with key: " + key);
            }
        }

        public void UpdateTotalInventoryAfterReduction(Item item, int amountToReduce)
        {
            try
            {
                var itemCollection = database.GetCollection<Item>("Items");

                if (item.hasEnoughInventory)
                {
                    item.totalInventory -= amountToReduce;
                    itemCollection.Update(item);
                }
            }
            catch
            {
                Console.WriteLine("Error occured please try again");
            }
        }

        public void CheckItemHasEnoughInventory(Item item, int amountToReduce)
        {
            if (amountToReduce <= item.totalInventory)
            {
                item.hasEnoughInventory = true;
            }
            else
            {
                item.hasEnoughInventory = false;
            }
        }

        public void ReduceInventory(Item item, Order order)
        {
            var amountToReduce = order.amountOrdered[item.id];
            CheckItemHasEnoughInventory(item, amountToReduce);
            if (item.hasEnoughInventory)
            {
                UpdateTotalInventoryAfterReduction(item, amountToReduce);
            }
            else
            {
                order.isValid = false;
                Console.WriteLine("Item " + item.name + " could not be ordered due to insufficent inventory");
            }

        }
    }
}
