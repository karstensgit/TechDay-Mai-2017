using System.Collections.Generic;

namespace SupermarketStuff.Interfaces
{
    interface IInvoice
    {
        string ToString();
        //Liefert den Gesamtpreis der Rechnung
        double GetBill();
        //Liefert alle Items, die auf der Rechnung gekauft wurden
        List<IItem> GetListOfItems();
        //Beim abrechnen: fuegt ein Item der Rechnung hinzu
        void AddItem(IItem item);
    }
}
