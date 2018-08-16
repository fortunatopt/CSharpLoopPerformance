using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDebug
{
    class Program
    {

        static void Main(string[] args)
        {
            string type = "";
            Console.Write("Object or Integers (o or i)?: ");
            type = Console.ReadLine();

            if (type.ToLower() != "o" && type.ToLower() != "i")
            {
                Console.WriteLine("That is not a valid choice, so Integer it is");
                type = "i";
            }

            long iterator = 0;
            string l = "";

            if (type == "i")
            {
                Console.Write($"How many loops ( <= {iterator} )?: ");
                l = Console.ReadLine();
                bool test = long.TryParse(l, out iterator);
                if (iterator == 0 || iterator > 100000000)
                    iterator = 100000000;

                Console.WriteLine();
                Console.WriteLine($"We will loop {iterator} times");
                Console.WriteLine();

                iterator.IntLoop();
            }
            else
            {                
                Console.Write($"How many loops ( <= {iterator} )?: ");
                l = Console.ReadLine();
                bool test = long.TryParse(l, out iterator);
                if (iterator == 0 || iterator > 10000000)
                    iterator = 10000000;

                Console.WriteLine();
                Console.WriteLine($"We will loop {iterator} times");
                Console.WriteLine();

                iterator.ObjLoop();
            }

            Console.WriteLine();
            Console.Write("Press enter...you are done");
            Console.ReadKey();
        }
    }
}