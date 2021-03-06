﻿using System;
using SupermarketStuff.Interfaces;

namespace SupermarketStuff.Implementation.Default
{
    class DefaultCustomer : ICustomer
    {
        private double moneyInPocket;
        private IShoppingCart shoppingCart;

        public DefaultCustomer()
        {
            this.moneyInPocket = 250;
            this.shoppingCart = new DefaultShoppingCart();
        }

        public IShoppingCart GetCart()
        {
            return shoppingCart;
        }

        public void SetCart(IShoppingCart newCart)
        {
            this.shoppingCart = newCart;
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

        public void AddItemToCart(IItem item)
        {
            shoppingCart.AddItem(item);
        }
    }
}
