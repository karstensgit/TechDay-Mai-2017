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

        public DefaultItem(string name, double price)
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

        public override string ToString()
        {
            return name + price;
        }

        public override bool Equals(object obj)
        {
            IItem i = (IItem)obj;
            if (this.GetName().Equals(i.GetName()))
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
