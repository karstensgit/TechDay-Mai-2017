using System.Collections.Generic;

namespace SupermarketStuff.Interfaces
{
    interface IShoppingCart
    {
        List<IItem> GetItemsInCart();
        void DoDestruct();
    }
}
