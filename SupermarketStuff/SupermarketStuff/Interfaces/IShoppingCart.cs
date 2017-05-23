﻿using System.Collections.Generic;

namespace SupermarketStuff.Interfaces
{
    interface IShoppingCart
    {
        List<IItem> GetItemsInCart();
        //uebt einen destruktor, ihr koennt z.B. alle verbliebenen Items printen,
        //falls der ShoppingCart nicht geleert wurde
        void DoDestruct();
    }
}
