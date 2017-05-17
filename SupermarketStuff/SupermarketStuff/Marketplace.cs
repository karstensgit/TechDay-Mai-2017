using System;
using System.Collections.Generic;
using System.Text;
using SupermarketStuff.Interfaces;

namespace SupermarketStuff
{
    class Marketplace
    {
        private static Marketplace Instance;
        private static readonly object _lock = new object();
        private readonly List<ISupplier> _suppliers;

        private Marketplace()
        {
            _suppliers = new List<ISupplier>();
        }

        public static Marketplace GetInstance()
        {
            lock (_lock)
            {
                if (Instance == null)
                    Instance = new Marketplace();
                return Instance;
            }
        }

        public void RegisterSupplier(ISupplier toAdd)
        {
            if(_suppliers.Contains(toAdd))
                return;
            _suppliers.Add(toAdd);
        }

        public ISupplier FindSupplier(IItem item)
        {
            foreach(ISupplier supplier in _suppliers)
            {
                if (supplier.Sells(item))
                    return supplier;
            }
            return null;
        }

    }
}
