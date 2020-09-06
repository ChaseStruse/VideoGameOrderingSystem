using System;
using System.Collections.Generic;
using System.Text;

namespace VideoGameOrderingSystem.Data.Models
{
    public class Item
    {
        private int id;
        private string name;
        private string description;
        private Categories category;
        private double price;
        private int totalOrdered;
        private int totalInventory;

        public Item(int id, string name, string description, Categories category, double price, int totalOrdered, int totalInventory)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.category = category;
            this.price = price;
            this.totalOrdered = totalOrdered;
            this.totalInventory = totalInventory;
        }

        public int getID()
        {
            return id; 
        }
        public string getName()
        {
            return name;
        }
        public string getDescription()
        {
            return description;
        }
        public Categories getCategory()
        {
            return category;
        }
        public double getPrice()
        {
            return price;
        }
        public int getTotalOrdered()
        {
            return totalOrdered;
        }
        public void setTotalOrdered(int totalOrdered)
        {
            this.totalOrdered = totalOrdered;
        }
        public int getTotalInventory()
        {
            return totalInventory;
        }
    }
}
