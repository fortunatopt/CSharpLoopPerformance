using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDebug
{
    public static class IntegerLoop
    {
        public static void IntLoop()
        {

            long iterator = 100000000;
            string l = "";

            Console.Write($"How many loops ( <= {iterator} )?: ");
            l = Console.ReadLine();
            bool test = long.TryParse(l, out iterator);
            if (iterator == 0 || iterator > 100000000)
                iterator = 100000000;

            Console.WriteLine();
            Console.WriteLine($"We will loop {iterator} times");
            Console.WriteLine();

            List<Output> output = new List<Output>();

            List<int> rows = PopulateLoop(iterator);
            int[] rowsArray = PopulateArray(iterator);
            Stopwatch sw = new Stopwatch();

            sw.Start();
            IterateForeachOnList(rows);
            sw.Stop();
            output.Add(new Output { Title = "Iterate Foreach On List", Milliseconds = sw.ElapsedTicks });

            sw = new Stopwatch();
            sw.Start();
            IterateForOnListWithoutCountOptimization(rows);
            sw.Stop();
            output.Add(new Output { Title = "Iterate For On List Without Count Optimization", Milliseconds = sw.ElapsedTicks });

            sw = new Stopwatch();
            sw.Start();
            IterateForOnListWithCountOptimization(rows);
            sw.Stop();
            output.Add(new Output { Title = "Iterate For On List With Count Optimization", Milliseconds = sw.ElapsedTicks });

            sw = new Stopwatch();
            sw.Start();
            IterateForeachOnArray(rowsArray);
            sw.Stop();
            output.Add(new Output { Title = "Iterate Foreach On Array", Milliseconds = sw.ElapsedTicks });

            sw = new Stopwatch();
            sw.Start();
            IterateForOnArrayWithoutCountOptimization(rowsArray);
            sw.Stop();
            output.Add(new Output { Title = "Iterate For On Array Without Count Optimization", Milliseconds = sw.ElapsedTicks });

            sw = new Stopwatch();
            sw.Start();
            IterateForOnArrayWithCountOptimization(rowsArray);
            sw.Stop();
            output.Add(new Output { Title = "Iterate For On Array With Count Optimization", Milliseconds = sw.ElapsedTicks });

            foreach (var o in output)
                Console.WriteLine(String.Format("| {0,50} | {1,20} |", o.Title, o.Milliseconds.ToString("N0")));
        }
        static List<int> PopulateLoop(long rows)
        {
            List<int> ints = new List<int>();
            for (int i = 0; i < rows; i++)
                ints.Add(i);
            return ints;
        }
        static int[] PopulateArray(long rows)
        {
            List<int> ints = new List<int>();
            for (int i = 0; i < rows; i++)
                ints.Add(i);
            return ints.ToArray();
        }
        static void IterateForeachOnList(List<int> list)
        {
            foreach (int i in list) { int j = i; }
        }
        static void IterateForOnListWithoutCountOptimization(List<int> list)
        {
            for (int i = 0; i < list.Count; i++) { int j = list[i]; }
        }
        static void IterateForOnListWithCountOptimization(List<int> list)
        {
            int count = list.Count;
            for (int i = 0; i < count; i++) { int j = list[i]; }
        }
        static void IterateForeachOnArray(int[] array)
        {
            foreach (int i in array) { int j = i; }
        }
        static void IterateForOnArrayWithoutCountOptimization(int[] array)
        {
            for (int i = 0; i < array.Length; i++) { int j = array[i]; }
        }
        static void IterateForOnArrayWithCountOptimization(int[] array)
        {
            int length = array.Length;
            for (int i = 0; i < length; i++) { int j = array[i]; }
        }
    }
}
