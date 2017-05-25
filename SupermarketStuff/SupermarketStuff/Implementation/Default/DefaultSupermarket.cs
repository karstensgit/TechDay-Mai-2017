using System.Collections.Generic;
using SupermarketStuff.Interfaces;
using System;

namespace SupermarketStuff.Implementation.Default
{
    class DefaultSupermarket : ISupermarket
    {
        private readonly List<IInvoice> _invoices;
        private readonly Dictionary<IItem, uint> _stock;

        public DefaultSupermarket()
        {
            _invoices = new List<IInvoice>();
            _stock = new Dictionary<IItem, uint>();
        }

        public double OrderItems(IItem item, uint amount)
        {
            ISupplier supplierForItem = Marketplace.GetInstance().FindSupplier(item);
            if (supplierForItem == null)
                return 0.0;
            if (_stock.ContainsKey(item))
            {
                _stock[item] += amount;
            } else
            {
                _stock.Add(item, amount);
            }
            return supplierForItem.Buy(item, amount);
        }

        public List<IItem> GetItems()
        {       
            List<IItem> keyList = new List<IItem>(_stock.Keys);
            return keyList;
        }

        public void PrintSales()
        {
            double sales = 0;
            foreach (IInvoice invoice in _invoices)
            {
                sales += invoice.GetBill();
            }
            Console.WriteLine("Total sales: " + sales);
        }

        public IInvoice Checkout(ICustomer toCheckoutCustomer)
        {
            var itemsInCustomersCart = toCheckoutCustomer.GetCart().GetItemsInCart();
            double checkoutTotal = 0.0;
            foreach (IItem itemInCart in itemsInCustomersCart)
            {
                checkoutTotal += itemInCart.GetPrice();
                _stock[itemInCart] -= 1;
            }
            
            if (checkoutTotal > toCheckoutCustomer.GetMoneyInPocket()) //Withdraw some money
                toCheckoutCustomer.WithdrawMoney((int) (checkoutTotal - toCheckoutCustomer.GetMoneyInPocket()));
            
            toCheckoutCustomer.SetCart(null);
            IInvoice generatedInvoice = new DefaultInvoice(itemsInCustomersCart);
            _invoices.Add(generatedInvoice);
            return generatedInvoice;
        }
    }
}