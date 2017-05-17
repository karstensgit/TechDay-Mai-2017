using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketStuff.Interfaces
{
    interface ICustomer
    {
        IShoppingCart GetCart();
        void SetCart(IShoppingCart newCart);
        bool BuyCart();
        void WithdrawMoney(int amount);
        double GetMoneyInPocket();
    }
}