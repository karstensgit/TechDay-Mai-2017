using System.Collections.Generic;
using SupermarketStuff.Interfaces;

namespace SupermarketStuff.Implementation.Default
{
    class DefaultShoppingCart : IShoppingCart
    {
        private readonly List<IItem> _itemsInCart;

        public DefaultShoppingCart() : this(20)
        {
            
        }

        public DefaultShoppingCart(int maxSize)
        {
            _itemsInCart = new List<IItem>(maxSize);
        }

        public List<IItem> GetItemsInCart()
        {
            return _itemsInCart;
        }

        //Destructor
        ~DefaultShoppingCart() {
            DoDestruct();
        }

        public void DoDestruct()
        {
            //Delete everything
            foreach (IItem item in _itemsInCart)
                _itemsInCart.Remove(item);
        }
    }
}