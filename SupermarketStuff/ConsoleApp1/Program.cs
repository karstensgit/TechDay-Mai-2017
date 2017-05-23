using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    struct SimpleStructure
    {
        int Number { get; set; }
        public string name;

        public SimpleStructure(int number, string name)
        {
            this.Number = number;
            this.name = "karsten";
        }

        public int Method()
        {
            return Number;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dynamo();
            Console.ReadKey();
        }




        static void HowToArray()
        {
            int[] eindimensional = new int[5];

            int[,,] dreidimensional = new int[1, 2, 3];

            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[1];
            jaggedArray[1] = new int[5];
            jaggedArray[2] = new int[4];
        }




        static void KeepItSafe()
        {
            //Compiler uebernimmt Typenzuordnung, falls eindeutig
            string[] words = { "apple", "strawberry", "grape" };
            var wordQuery = from word in words
                            where word[0] == 'g'
                            select word;
            //Aequivalent mit dem oberen Code
            IEnumerable<string> same = from word in words
                                       where word[0] == 'g'
                                       select word;

            SimpleStructure one = new SimpleStructure(1, "");
            SimpleStructure two = new SimpleStructure(2, "");
            SimpleStructure three = new SimpleStructure(3, "");
            SimpleStructure four = new SimpleStructure(4, "");
            SimpleStructure[] structures = { one, two, three, four };

            //var keyword notwendig, da der Compiler bei anonymen Klassen nicht den Typ kennt
            var wordQueryTwo = from s in structures
                               where s.Method() == 2
                               select new { s.name };
        }

        static void Dynamo()
        {
            //dynamics werden erst zur Laufzeit einem Typ zugeordnet 
            dynamic dyn = 1;
            dynamic dyn2 = new SimpleStructure(1, "Harald");
            object obj = 1;
            var var = 1;

            Console.WriteLine("dyn: {0}", dyn.GetType());
            Console.WriteLine("dyn2: " + dyn2.GetType());
            Console.WriteLine("obj: " + obj.GetType());
            Console.WriteLine("var: " + var.GetType());
        }

        
        
        //Delegate in C# funktionieren wie Funktionszeiger (z.B. aus C++)

        //Delegat deklarieren
        delegate double DelegateAction(double num);

        //Normale Methode mit passender Signatur
        static double HalfThatShit(double input)
        {
            return input / 2;
        }

        static void DelegateSomeStuff()
        {
            //Delegaten instanziieren mit voriger Methode
            DelegateAction action = HalfThatShit;
            //Delegaten ausführen
            double a = action(2.1); // a = 1.05

            //geht auch mit anonymer Methode
            DelegateAction action2 = delegate (double input)
            {
                return input * 2;
            };
            a = action2(2.1); // a = 4.2

            //oder mit lambdas..
            DelegateAction action3 = s => s + s + s;
            a = action3(2.1); // a = 6.3
        }
    }




    interface ISampleInterface
    {
        void SampleMethod();
    }

    interface ISampleInterfaceTwo
    {
        void SampleMethod();
    }

    class IchImplementiereDasInterface : ISampleInterface, ISampleInterfaceTwo
    {
        //implizite Implementierung
        public void SampleMethod()
        {
            throw new NotImplementedException();
        }

        //explizite Implementierung
        void ISampleInterface.SampleMethod()
        {
            throw new NotImplementedException();
        }

        public IchImplementiereDasInterface()
        {
            Console.WriteLine("Objekt instanziiert");
        }

        //Ein Destruktor wird erst dann aufgerufen, wenn das Programm sich beendet 
        //oder das Objekt vom Garbage Collector geholt wird.
        //Es ist nicht moeglich, den Destruktor manuell aufzurufen
        ~IchImplementiereDasInterface()
        {
            Console.WriteLine("Nun holt mich der Boogey Man");
        }



        //Unbestimmte Anzahl von Parametern koennen direkt als Array gespeichert werden
        static void VieleInputs(string a, params int[] input)
        {
            foreach (int num in input)
            {
                //...
            }
        }

        //Referenz auf input wird uebergeben, input muss vorher instanziiert werden
        static void ReferenzParameter(ref int input)
        {
            input = input + 100;
        }

        //Referenz wird uebergeben, input muss vorher nicht instanziiert werden
        static void AusgabeParameter(out int input)
        {
            input = 17;
        }

        static void NotMain()
        {
            int num = 1;
            ReferenzParameter(ref num); //num = 101
            int num2;
            AusgabeParameter(out num2); //num2 = 17
        }
    }
}