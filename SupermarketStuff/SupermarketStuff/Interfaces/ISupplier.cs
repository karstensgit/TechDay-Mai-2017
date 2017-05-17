using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketStuff.Interfaces
{
    interface ISupplier
    {
        Boolean Sells(IItem item);
    }
}
