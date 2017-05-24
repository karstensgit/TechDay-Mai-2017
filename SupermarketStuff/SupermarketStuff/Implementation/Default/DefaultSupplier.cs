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

        public double Buy(IItem item, double amount)
        {
            return GetPricePerItem(item) * amount;
        }

        public double GetPricePerItem(IItem item)
        {
            if (ItemsWithSupplyPrice.ContainsKey(item))
            {
                return ItemsWithSupplyPrice[item];
            } else
            {
                return 0;
            }
        }

        public bool Sells(IItem item)
        {
            foreach (IItem pivot in ItemsWithSupplyPrice.Keys)
                if (pivot.Equals(item)) return true;
            return false;

        }

        public override string ToString()
        {
            List<IItem> keyList = new List<IItem>(ItemsWithSupplyPrice.Keys);
            string result = "Supplier: ";
            foreach (IItem item in keyList)
            {
                result = result + item.ToString() + "; ";
            }
            return result;
        }
    }
}
