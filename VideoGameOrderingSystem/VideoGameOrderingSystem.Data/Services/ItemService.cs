using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using VideoGameOrderingSystem.Data.Models;

namespace VideoGameOrderingSystem.Data.Services
{
    public class ItemService
    {
        private LiteDatabase database = new LiteDatabase(@"D:\Developer\C#\VideoGameOrderingSystem\VideoGameOrderingSystem\VideoGameOrderingSystem.Data\Database\Main.db");
        public void AddItemToDatabase(Item item)
        {
            var itemCollection = database.GetCollection<Item>("Items");

            if (GetItem(item.id) == null) itemCollection.Insert(item);
            else Console.WriteLine("Item with this ID already exists please try again");
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

        public void ReduceInventory(int key, int amountToReduce)
        {
            try
            {
                var itemCollection = database.GetCollection<Item>("Items");
                var item = GetItem(key);

                if(item != null && amountToReduce <= item.totalInventory)
                {
                    item.totalInventory -= amountToReduce;
                    itemCollection.Update(item);
                }
                else
                {
                    if (item == null) Console.WriteLine("Could not find item with key: " + key);
                    else Console.WriteLine("Amount to reduce was greater than total inventory. Total inventory is " + item.totalInventory);
                }
            }
            catch
            {
                Console.WriteLine("Error occured please try again");
            }
        }
    }
}
