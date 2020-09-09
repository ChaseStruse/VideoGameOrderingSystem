using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using VideoGameOrderingSystem.Data.Models;

namespace VideoGameOrderingSystem
{
    public class OrderingService
    {
        private LiteDatabase database = new LiteDatabase(@"D:\Developer\C#\VideoGameOrderingSystem\VideoGameOrderingSystem\VideoGameOrderingSystem.Data\Database\Main.db");

        public void CommitOrderToDatabase(Order order)
        {
            try
            {
                if (order.isValid)
                {
                    var orderCollection = database.GetCollection<Order>("Orders");
                    orderCollection.Insert(order);
                }
            }
            catch
            {
                Console.WriteLine("There was an error please try again");
            }
        }
    }
}
