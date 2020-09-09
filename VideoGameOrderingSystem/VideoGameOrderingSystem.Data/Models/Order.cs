using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace VideoGameOrderingSystem.Data.Models
{
    public class Order
    {
        private int id { get; set; }
        private DateTime fulfillDate { get; set; }
        private Dictionary<int, Item> items { get; set; }
    }
}
