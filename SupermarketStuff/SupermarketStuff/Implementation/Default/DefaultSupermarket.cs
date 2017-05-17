using System.Collections.Generic;
using SupermarketStuff.Interfaces;

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

            _stock[item] += amount;
            return supplierForItem.Buy(item, amount));
        }

        public void PrintSales()
        {
            
        }

        public void Checkout(ICustomer toCheckoutCustomer)
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
        }
    }
}