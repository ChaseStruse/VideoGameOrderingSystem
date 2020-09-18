using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using VideoGameOrderingSystem.Data.Models;

namespace VideoGameOrderingSystem.Data.Services
{
    public class ItemService
    {
        public void AddItemToDatabase(Item item, LiteDatabase database)
        {
            var itemCollection = database.GetCollection<Item>("Items");

            if (GetItem(item.id, database) == null) itemCollection.Insert(item);
            else Console.WriteLine("Item with this ID already exists please try again");
        }

        public Item GetItem(int key, LiteDatabase database)
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

        public void AddInventory(int key, int amountToAdd, LiteDatabase database)
        {
            try
            {
                var itemCollection = database.GetCollection<Item>("Items");
                var item = GetItem(key, database);

                item.totalInventory += amountToAdd;
                itemCollection.Update(item);
            }
            catch
            {
                Console.WriteLine("Could not find item with key: " + key);
            }
        }

        public void UpdateTotalInventoryAfterReduction(Item item, int amountToReduce, LiteDatabase database)
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

        public void ReduceInventory(Item item, Order order, LiteDatabase database)
        {
            var amountToReduce = order.amountOrdered[item.id];
            CheckItemHasEnoughInventory(item, amountToReduce);
            if (item.hasEnoughInventory)
            {
                UpdateTotalInventoryAfterReduction(item, amountToReduce, database);
            }
            else
            {
                order.isValid = false;
                Console.WriteLine("Item " + item.name + " could not be ordered due to insufficent inventory");
            }

        }
    }
}
