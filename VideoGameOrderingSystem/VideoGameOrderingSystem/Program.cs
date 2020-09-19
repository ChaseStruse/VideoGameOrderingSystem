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


            //OrderingService orderingService = new OrderingService();
            
            LiteDatabase database = new LiteDatabase(@"D:\Developer\C#\VideoGameOrderingSystem\VideoGameOrderingSystem\VideoGameOrderingSystem.Data\Database\Main.db");
            IItemService itemService = new ItemService(database);

            var halo = itemService.GetItem(1);
            var callOfDuty = itemService.GetItem(2);
            
            Order order = new Order();

            //orderingService.AddItemToOrder(order, halo, 1);
            //orderingService.AddItemToOrder(order, callOfDuty, 1);
            
            //itemService.AddItemToDatabase(item);
            
            var itemResult = itemService.GetItem(2);

            Console.WriteLine(itemResult.id + " " + itemResult.name + " " + itemResult.description + " " + itemResult.category + " " + itemResult.price + " " + itemResult.totalInventory);
            Console.WriteLine("--------------------------------");
            Console.WriteLine(order.id + " " + order.items.Values);
        }
    }
}
