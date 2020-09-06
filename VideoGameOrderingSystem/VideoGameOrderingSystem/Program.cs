using LiteDB;
using System;
using VideoGameOrderingSystem.Data.Models;
using VideoGameOrderingSystem.Data.Services;

namespace VideoGameOrderingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            LiteDatabase database = new LiteDatabase(@"D:\Developer\C#\VideoGameOrderingSystem\VideoGameOrderingSystem\VideoGameOrderingSystem.Data\Database\Items.db");
            var itemCollection = database.GetCollection<Item>("Items");
            ItemService itemService = new ItemService();

            Item item = new Item(1, "Halo", "Best FPS known to man kind", Categories.FirstPersonShooter, 60, 0, 10);

            itemService.AddItemToDatabase(item);

            var result = itemCollection.Query()
                            .Where(x => x.getID() == item.getID())
                            .FirstOrDefault();

            Console.WriteLine(result.getID() + " " + result.getName());

        }
    }
}
