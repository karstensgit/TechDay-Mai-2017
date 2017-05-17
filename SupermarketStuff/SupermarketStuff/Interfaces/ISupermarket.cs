using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketStuff.Interfaces
{
    interface ISupermarket
    {
        double OrderItems(IItem item, int amount);
        void printSales();
    }
}
