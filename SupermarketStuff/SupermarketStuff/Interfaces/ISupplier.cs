using System;
using System.Collections.Generic;

namespace SupermarketStuff.Interfaces
{
    interface ISupplier
    {
        //true, falls der supplier das item verkauft, ansonsten false
        Boolean Sells(IItem item);
        //fuegt ein neues item dem supplier hinzu. Sobald einmal hinzugefuegt, verfuegt der supplier ueber unbegrenzte ressourcen
        void AddItem(IItem item, double SupplyPrice);
        //liefert den Preis zum angegebenen Item zurueck, zum speichern bietet sich ein Dictionary an
        double GetPricePerItem(IItem item);
        //die Methode um  dem Supermarkt das angegebene item mit der angegebenen stueckzahl zu liefern
        double Buy(IItem item, double amount);
    }
}
