namespace SupermarketStuff.Interfaces
{
    internal interface ICustomer
    {
        IShoppingCart GetCart();
        void SetCart(IShoppingCart newCart);
        bool BuyCart();
        void WithdrawMoney(int amount);
        double GetMoneyInPocket();
    }
}