using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopPerformance
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

            if (type == "i")
            {
                IntegerLoop.IntLoop();
            }
            else
            {
                ObjectLoop.ObjLoop();
            }

            Console.WriteLine();
            Console.Write("Press enter...you are done");
            Console.ReadKey();
        }
    }
}