using System;
using System.Collections.Generic;

namespace SupermarketStuff.Interfaces
{
    interface ISupplier
    {
        Boolean Sells(IItem item);
        void AddItem(IItem item, double SupplyPrice);
        double GetPricePerItem(IItem item);
    }
}
