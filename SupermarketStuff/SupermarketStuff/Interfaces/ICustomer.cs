namespace SupermarketStuff.Interfaces
{
    internal interface ICustomer
    {
        bool BuyCart();
        void WithdrawMoney(double amount);
    }
}