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
            ISupplier s = Marketplace.GetInstance().FindSupplier(new DefaultItem("Banana", 0.5));
            supermarket.OrderItems(new DefaultItem("Banana", 0.5), 100);
            supermarket.OrderItems(new DefaultItem("Apple", 0.3), 100);
            supermarket.OrderItems(new DefaultItem("Coconut", 3.5), 100);
        }

        private static void AddDefaultSupplier()
        {
            DefaultSupplier s = new DefaultSupplier();
            s.AddItem(new DefaultItem("Banana", 0.5), 0.3);
            s.AddItem(new DefaultItem("Apple", 0.3), 0.15);
            s.AddItem(new DefaultItem("Coconut", 3.5), 2);
            Marketplace.GetInstance().RegisterSupplier(s);
        }

        private static void RunScenario()
        {
            Console.WriteLine(" ");
            Console.WriteLine("You are the customer, what do you want to do?");
            Console.WriteLine("1. buy some stuff \n2. checkout your shopping cart");
            ReadInput(Console.ReadLine());

        }

        private static List<IItem> GetAvailableItems()
        {
            return supermarket.GetItems();
        }

        private static void ReadInput(string input)
        {
            switch (input)
            {
                case "buy":
                    ProceedBuyRequest();
                    return;
                case "checkout":
                    ProceedCheckoutRequest();
                    return;
                default:
                    Console.WriteLine("Hey douche, choose valid stuff!");
                    ReadInput(Console.ReadLine());
                    return;
            }
        }

        private static void ProceedBuyRequest()
        {
            Console.WriteLine("These items are available: ");
            for (int i = 0; i < GetAvailableItems().Count; i++)
            {
                Console.WriteLine(i+1 + " " + GetAvailableItems()[i].ToString());
            }
            try
            {
                int option = Int32.Parse(Console.ReadLine());
                customer.AddItemToCart(GetAvailableItems()[option - 1]);
                Console.WriteLine("Added {0} to your cart", GetAvailableItems()[option - 1]);
                RunScenario();
            } catch
            {
                Console.WriteLine("Hey douche, choose valid stuff!");
                RunScenario();
            }
        }

        private static void ProceedCheckoutRequest()
        {
            supermarket.Checkout(customer);
            Console.WriteLine("Successfully checked out, good bye");
        }
    }
}