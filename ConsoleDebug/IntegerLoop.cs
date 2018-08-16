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

            output.Add(new Output { Title = "============================================================", Time = "==================" });
            output.Add(new Output { Title = "List Iteration", Time = "Ticks" });
            output.Add(new Output { Title = "============================================================", Time = "==================" });

            sw.Start();
            IterateForeachOnList(rows);
            sw.Stop();
            output.Add(new Output { Title = "Iterate Foreach On List", Time = sw.ElapsedTicks.ToString("N0") });

            sw = new Stopwatch();
            sw.Start();
            IterateForOnListWithoutCountOptimization(rows);
            sw.Stop();
            output.Add(new Output { Title = "Iterate For On List Without Count Optimization", Time = sw.ElapsedTicks.ToString("N0") });

            sw = new Stopwatch();
            sw.Start();
            IterateForOnListWithCountOptimization(rows);
            sw.Stop();
            output.Add(new Output { Title = "Iterate For On List With Count Optimization", Time = sw.ElapsedTicks.ToString("N0") });

            output.Add(new Output { Title = "============================================================", Time = "==================" });
            output.Add(new Output { Title = "Parallel List Iteration", Time = "Ticks" });
            output.Add(new Output { Title = "============================================================", Time = "==================" });

            sw = new Stopwatch();
            sw.Start();
            IterateParallelForeachOnList(rows);
            sw.Stop();
            output.Add(new Output { Title = "Iterate Parallel Foreach On List", Time = sw.ElapsedTicks.ToString("N0") });

            sw = new Stopwatch();
            sw.Start();
            IterateParallelForOnListWithoutCountOptimization(rows);
            sw.Stop();
            output.Add(new Output { Title = "Iterate Parallel For On List Without Count Optimization", Time = sw.ElapsedTicks.ToString("N0") });

            sw = new Stopwatch();
            sw.Start();
            IterateParallelForOnListWithCountOptimization(rows);
            sw.Stop();
            output.Add(new Output { Title = "Iterate Parallel For On List With Count Optimization", Time = sw.ElapsedTicks.ToString("N0") });

            output.Add(new Output { Title = "============================================================", Time = "==================" });
            output.Add(new Output { Title = "Array Iteration", Time = "Ticks" });
            output.Add(new Output { Title = "============================================================", Time = "==================" });

            sw = new Stopwatch();
            sw.Start();
            IterateForeachOnArray(rowsArray);
            sw.Stop();
            output.Add(new Output { Title = "Iterate Foreach On Array", Time = sw.ElapsedTicks.ToString("N0") });

            sw = new Stopwatch();
            sw.Start();
            IterateForOnArrayWithoutCountOptimization(rowsArray);
            sw.Stop();
            output.Add(new Output { Title = "Iterate For On Array Without Count Optimization", Time = sw.ElapsedTicks.ToString("N0") });

            sw = new Stopwatch();
            sw.Start();
            IterateForOnArrayWithCountOptimization(rowsArray);
            sw.Stop();
            output.Add(new Output { Title = "Iterate For On Array With Count Optimization", Time = sw.ElapsedTicks.ToString("N0") });

            output.Add(new Output { Title = "============================================================", Time = "==================" });
            output.Add(new Output { Title = "Parallel Array Iteration", Time = "Ticks" });
            output.Add(new Output { Title = "============================================================", Time = "==================" });

            sw = new Stopwatch();
            sw.Start();
            IterateParallelForeachOnArray(rowsArray);
            sw.Stop();
            output.Add(new Output { Title = "Iterate Parallel Foreach On Array", Time = sw.ElapsedTicks.ToString("N0") });

            sw = new Stopwatch();
            sw.Start();
            IterateParallelForOnArrayWithoutCountOptimization(rowsArray);
            sw.Stop();
            output.Add(new Output { Title = "Iterate Parallel For On Array Without Count Optimization", Time = sw.ElapsedTicks.ToString("N0") });

            sw = new Stopwatch();
            sw.Start();
            IterateParallelForOnArrayWithCountOptimization(rowsArray);
            sw.Stop();
            output.Add(new Output { Title = "Iterate Parallel For On Array With Count Optimization", Time = sw.ElapsedTicks.ToString("N0") });
            output.Add(new Output { Title = "============================================================", Time = "==================" });

            foreach (var o in output)
                Console.WriteLine(String.Format("| {0,60} | {1,20} |", o.Title, o.Time));
            
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

        static void IterateParallelForeachOnList(List<int> list)
        {
            Parallel.ForEach(list, i => { int j = i; });
        }
        static void IterateParallelForOnListWithoutCountOptimization(List<int> list)
        {
            Parallel.For(0, list.Count(), i => { int j = i; });
        }
        static void IterateParallelForOnListWithCountOptimization(List<int> list)
        {
            int count = list.Count();
            Parallel.For(0, count, i => { int j = i; });
        }

        static void IterateParallelForeachOnArray(int[] array)
        {
            Parallel.ForEach(array, i => { int j = i; });
        }
        static void IterateParallelForOnArrayWithoutCountOptimization(int[] array)
        {
            Parallel.For(0, array.Count(), i => { int j = array[i]; });
        }
        static void IterateParallelForOnArrayWithCountOptimization(int[] array)
        {
            int count = array.Count();
            Parallel.For(0, count, i => { int j = array[i]; });
        }
    }
}
