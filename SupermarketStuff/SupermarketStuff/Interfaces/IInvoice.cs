using System.Collections.Generic;

namespace SupermarketStuff.Interfaces
{
    interface IInvoice
    {
        string ToString();
        double GetBill();
        void SetBill();
        List<IItem> GetListOfItems();
        void AddItem(IItem item);
    }
}
