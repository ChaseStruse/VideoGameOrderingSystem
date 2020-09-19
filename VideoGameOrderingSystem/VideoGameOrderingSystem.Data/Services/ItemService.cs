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
        bool AddItemToDatabase(Item item);
        Item GetItem(int key);
        bool AddInventory(int key, int amountToAdd);
        bool UpdateTotalInventoryAfterReduction(Item item, int amountToReduce);
        void CheckItemHasEnoughInventory(Item item, int amountToReduce);
        bool ReduceInventory(Item item, Order order);
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

        public bool AddInventory(int key, int amountToAdd)
        {
            bool inventoryAdded;
            try
            {
                var item = GetItem(key);
                item.totalInventory += amountToAdd;
                itemCollection.Update(item);
                inventoryAdded = true;
            }
            catch
            {
                inventoryAdded = false;
            }

            return inventoryAdded;
        }

        public bool UpdateTotalInventoryAfterReduction(Item item, int amountToReduce)
        {
            bool inventoryUpdated = false;
            try
            {
                var itemCollection = database.GetCollection<Item>("Items");

                if (item.hasEnoughInventory)
                {
                    item.totalInventory -= amountToReduce;
                    itemCollection.Update(item);
                    inventoryUpdated = true;
                }
            }
            catch
            {
                inventoryUpdated = false;
            }

            return inventoryUpdated;
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

        public bool ReduceInventory(Item item, Order order)
        {
            var amountToReduce = order.amountOrdered[item.id];

            CheckItemHasEnoughInventory(item, amountToReduce);
            
            if (item.hasEnoughInventory)
            {
                UpdateTotalInventoryAfterReduction(item, amountToReduce);
                order.isValid = true;
            }
            else
            {
                order.isValid = false;
            }

            return order.isValid;
        }
    }
}
