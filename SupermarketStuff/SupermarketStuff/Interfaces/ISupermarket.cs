namespace SupermarketStuff.Interfaces
{
    interface ISupermarket
    {
        double OrderItems(IItem item, int amount);
        void PrintSales();
    }
}
