using System.Collections.Generic;

namespace SupermarketStuff.Interfaces
{
    interface ISupermarket
    {
        //der Supermarkt bestellt bei dem Supplier seiner Wahl die entsprechende Menge eines items
        double OrderItems(IItem item, uint amount);
        //gibt die Summe aller Umsaetze in der Konsole aus
        void PrintSales();
        //kassiert einen Customer ab -> leert seinen Wagen und lässt ihn bezahlen
        void Checkout(ICustomer toCheckoutCustomer);
        //gibt alle items aus, die der Laden fuehrt
        List<IItem> GetItems();
    }
}
