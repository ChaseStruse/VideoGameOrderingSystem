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

            ItemService itemService = new ItemService();
            //OrderingService orderingService = new OrderingService();
            
            var halo = itemService.GetItem(1);
            var callOfDuty = itemService.GetItem(2);
            
            Order order = new Order();

            //orderingService.AddItemToOrder(order, halo, 1);
            //orderingService.AddItemToOrder(order, callOfDuty, 1);
            
            //itemService.AddItemToDatabase(item);
            
            var result = itemService.GetItem(2);

            Console.WriteLine(result.id + " " + result.name + " " + result.description + " " + result.category + " " + result.price + " " + result.totalInventory);

        }
    }
}
