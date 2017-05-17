namespace SupermarketStuff.Interfaces
{
    interface ISupermarket
    {
        double OrderItems(IItem item, uint amount);
        void PrintSales();
        void Checkout(ICustomer toCheckoutCustomer);
    }
}
