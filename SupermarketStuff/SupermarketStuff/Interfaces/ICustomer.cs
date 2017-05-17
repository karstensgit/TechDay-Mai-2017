namespace SupermarketStuff.Interfaces
{
    internal interface ICustomer
    {
        IShoppingCart GetCart();
        void SetCart(IShoppingCart newCart);
        void WithdrawMoney(int amount);
        double GetMoneyInPocket();
    }
}