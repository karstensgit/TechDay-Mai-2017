namespace SupermarketStuff.Interfaces
{
    internal interface ICustomer
    {
        IShoppingCart GetCart();
        void SetCart(IShoppingCart newCart);
        //hebt Geld ab, falls ihr aan der Kasse nicht genug dabei habt
        void WithdrawMoney(int amount);
        double GetMoneyInPocket();
    }
}