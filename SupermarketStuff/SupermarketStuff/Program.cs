using System;
using SupermarketStuff.Implementation.Default;
using SupermarketStuff.Interfaces;
using System.Collections.Generic;

namespace SupermarketStuff
{
    class Program
    {

        private static ISupermarket supermarket;
        private static ICustomer customer;
        private static IItem banana = new DefaultItem("banana", 0.5);


        static void Main(string[] args)
        {
            InitScenario();
            Console.WriteLine("Welcome to the tutorial, a scenario has been initialized for you");
            RunScenario();
            Console.ReadKey();
        }

        private static void InitScenario()
        {
            supermarket = new DefaultSupermarket();
            customer = new DefaultCustomer();
            AddDefaultSupplier();
            ISupplier s = Marketplace.GetInstance().FindSupplier(banana);
            supermarket.OrderItems(banana, 100);
            //supermarket.OrderItems(new DefaultItem("Banana", 0.5), 100);
            supermarket.OrderItems(new DefaultItem("Apple", 0.3), 100);
            supermarket.OrderItems(new DefaultItem("Coconut", 3.5), 100);
        }

        private static void AddDefaultSupplier()
        {
            DefaultSupplier s = new DefaultSupplier();
            //s.AddItem(new DefaultItem("Banana", 0.5), 0.3);
            s.AddItem(banana, 0.3);
            s.AddItem(new DefaultItem("Apple", 0.3), 0.15);
            s.AddItem(new DefaultItem("Coconut", 3.5), 2);
            Marketplace.GetInstance().RegisterSupplier(s);
        }

        private static void RunScenario()
        {
            Console.WriteLine("###########################################");
            Console.WriteLine("You are the customer, what do you want to do?");
            Console.WriteLine("1. add an item to your shopping cart \n2. checkout your shopping cart");
            try
            {
                int input = Int32.Parse(Console.ReadLine());
                Console.WriteLine("These items are available: ");
                for (int i = 1; i < GetAvailableItems().Count; i++)
                {
                    Console.WriteLine(i + GetAvailableItems()[i].ToString());
                }
            }
            catch
            {
                Console.WriteLine("Invalid option, shutting down... \n...\n...\ndouche!");
            }

        }

        private static List<IItem> GetAvailableItems()
        {
            return supermarket.GetItems();
        }
    }
}