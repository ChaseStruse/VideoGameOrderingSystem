using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using VideoGameOrderingSystem.Data.Models;

namespace VideoGameOrderingSystem.Data.Services
{
    public class ItemService
    {
        private LiteDatabase database = new LiteDatabase(@"D:\Developer\C#\VideoGameOrderingSystem\VideoGameOrderingSystem\VideoGameOrderingSystem.Data\Database\Items.db");
        public void AddItemToDatabase(Item item)
        {
            var itemCollection = database.GetCollection<Item>("Items");

            var result = itemCollection.Query()
                                        .Where(x => x.getID() == item.getID())
                                        .FirstOrDefault();

            if (result != null) Console.WriteLine("Item already exists with that ID");
            else
            {
                itemCollection.Insert(item);
            }
        }
    }
}
