using SupermarketStuff.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketStuff.Implementation.Default
{
    class DefaultInvoice : IInvoice
    {
        private List<IItem> items;
        private double bill;

        public DefaultInvoice()
        {
            this.items = new List<IItem>();
            this.bill = 0;
        }

        public DefaultInvoice(List<IItem> items)
        {
            this.items = items;
        }

        public void AddItem(IItem item)
        {
            items.Add(item);
            bill += item.GetPrice();
        }

        public double GetBill()
        {
            return bill;
        }

        public List<IItem> GetListOfItems()
        {
            return items;
        }
    }
}
