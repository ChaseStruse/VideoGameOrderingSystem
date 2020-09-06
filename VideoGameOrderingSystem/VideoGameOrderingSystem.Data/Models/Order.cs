using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace VideoGameOrderingSystem.Data.Models
{
    public class Order
    {
        private int id;
        private DateTime fulfillDate;
        private Dictionary<int, Item> items;

        public Order()
        {
            id = 0;
            fulfillDate = DateTime.Now;
            items = new Dictionary<int, Item>();
        }
        public Order(int id, DateTime fulfillDate, Dictionary<int, Item> items)
        {
            this.id = id;
            this.fulfillDate = fulfillDate;
            this.items = items;
        }

        public int getId()
        {
            return id;
        }
        public DateTime getFulfillDate()
        {
            return fulfillDate;
        }
        public Dictionary<int, Item> getItems()
        {
            return items;
        }
        public void SetItems(Dictionary<int, Item> items)
        {
            this.items = items;
        }
    }
}
