using SupermarketStuff.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketStuff.Implementation.Default
{
    class DefaultSupplier : ISupplier
    {
        private Dictionary<IItem, double> ItemsWithSupplyPrice;

        public DefaultSupplier()
        {
            this.ItemsWithSupplyPrice = new Dictionary<IItem, double>();
            Marketplace.GetInstance().RegisterSupplier(this);
        }

        public void AddItem(IItem item, double supplyPrice)
        {
            ItemsWithSupplyPrice.Add(item, supplyPrice);
        }

        public double GetPricePerItem(IItem item)
        {
            if (ItemsWithSupplyPrice.ContainsKey(item))
            {
                double result = 0;
                ItemsWithSupplyPrice.TryGetValue(item, out result);
                return result;
            } else
            {
                return 0;
            }
        }

        public bool Sells(IItem item)
        {
            return ItemsWithSupplyPrice.ContainsKey(item);
        }
    }
}
