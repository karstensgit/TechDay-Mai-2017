using System.Collections.Generic;
using SupermarketStuff.Interfaces;

namespace SupermarketStuff.Implementation.Default
{
    class DefaultSupermarket : ISupermarket
    {
        private readonly List<IInvoice> _invoices;
        private readonly Dictionary<IItem, uint> _stock;

        public DefaultSupermarket()
        {
            _invoices = new List<IInvoice>();
            _stock = new Dictionary<IItem, uint>();
        }

        public double OrderItems(IItem item, uint amount)
        {
            ISupplier supplierForItem = Marketplace.GetInstance().FindSupplier(item);
            if (supplierForItem == null)
                return 0.0;
            

        }

        public void PrintSales()
        {
            
        }
    }
}