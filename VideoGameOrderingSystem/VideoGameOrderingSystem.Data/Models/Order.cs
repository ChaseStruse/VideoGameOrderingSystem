﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Text;

namespace VideoGameOrderingSystem.Data.Models
{
    public class Order
    {
        public int id { get; set; }
        public DateTime fulfillDate { get; set; }
        public Dictionary<int, Item> items { get; set; }
        public Dictionary<int, int> amountOrdered { get; set; }
        public bool isValid { get; set; }

    }
}
