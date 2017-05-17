using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketStuff.Interfaces
{
    interface ICustomer
    {
        bool buyCart();
        void withdrawMoney(double amount);
    }
}