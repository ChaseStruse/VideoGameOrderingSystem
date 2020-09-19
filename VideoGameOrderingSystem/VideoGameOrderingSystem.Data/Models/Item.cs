using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace VideoGameOrderingSystem.Data.Models
{
    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Categories category { get; set; }
        public double price { get; set; }
        public int totalInventory { get; set; }
        public bool hasEnoughInventory { get; set; } = true;
    }
}
