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

            Item item = new Item
            {
                id = 1,
                name = "Halo",
                description = "Halo the best fps ever",
                category = Categories.FirstPersonShooter,
                price = 60.00,
                totalInventory = 10
            };

            itemService.AddItemToDatabase(item);
            itemService.AddInventory(item.id, 5);
            itemService.ReduceInventory(item.id, 5);

            var result = itemService.GetItem(item.id);

            Console.WriteLine(result.id + " " + result.name + " " + result.description + " " + result.category + " " + result.price + " " + result.totalInventory);

        }
    }
}
