﻿using System;
using System.Collections.Generic;
using System.Text;
using SupermarketStuff.Interfaces;

namespace SupermarketStuff.Implementation.Default
{
    class DefaultCustomer : ICustomer
    {
        private double moneyInPocket;
        private IShoppingCart shoppingCart;

        DefaultCustomer()
        {
            this.moneyInPocket = 250;
            this.shoppingCart = new DefaulShoppingCart();
        }

        public IShoppingCart GetCart()
        {
            return shoppingCart;
        }

        public void SetCart(IShoppingCart newCart)
        {
            this.shoppingCart = newCart;
        }

        public bool BuyCart()
        {
            throw new NotImplementedException();
        }

        public void WithdrawMoney(int amount)
        {
            if(amount > 500 || amount%5!=0)
            {
                Console.Write("Invalid amount!");
            }
            this.moneyInPocket += amount;
        }

        public double GetMoneyInPocket()
        {
            return moneyInPocket;
        }
    }
}
