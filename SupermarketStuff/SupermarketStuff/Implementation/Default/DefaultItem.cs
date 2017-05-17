using SupermarketStuff.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketStuff.Implementation.Default
{
    class DefaultItem : IItem
    {

        private string name;
        private double price;

        DefaultItem(string name, double price)
        {
            this.name = name;
            this.price = price;
        }

        public string GetName()
        {
            return name;
        }

        public double GetPrice()
        {
            return price;
        }
    }
}
