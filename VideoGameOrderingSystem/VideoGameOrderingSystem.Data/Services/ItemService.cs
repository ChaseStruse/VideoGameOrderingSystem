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
    }
}
