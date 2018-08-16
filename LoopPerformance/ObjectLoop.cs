using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopPerformance
{
    public static class ObjectLoop
    {
        public static void ObjLoop()
        {
            long iterator = 1000000;
            string l = "";

            Console.Write($"How many loops ( <= {iterator} )?: ");
            l = Console.ReadLine();
            bool test = long.TryParse(l, out iterator);
            if (iterator == 0 || iterator > 1000000)
                iterator = 1000000;

            Console.WriteLine();
            Console.WriteLine($"We will loop {iterator} times");
            Console.WriteLine();

            List<Output> output = new List<Output>();

            List<LoopObject> rows = PopulateLoop(iterator);
            LoopObject[] rowsArray = PopulateArray(iterator);
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
        static List<LoopObject> PopulateLoop(long rows)
        {
            List<LoopObject> objs = new List<LoopObject>();
            for (int i = 0; i < rows; i++)
                objs.Add(new LoopObject {
                    prop0 = "This is my data " + i,
                    prop1 = "This is my data " + i,
                    prop2 = "This is my data " + i,
                    prop3 = "This is my data " + i,
                    prop4 = "This is my data " + i,
                    prop5 = "This is my data " + i,
                    prop6 = "This is my data " + i,
                    prop7 = "This is my data " + i,
                    prop8 = "This is my data " + i,
                    prop9 = "This is my data " + i
                });
            return objs;
        }
        static LoopObject[] PopulateArray(long rows)
        {
            List<LoopObject> objs = PopulateLoop(rows);            
            return objs.ToArray();
        }

        static void IterateForeachOnList(List<LoopObject> list)
        {
            foreach (var i in list) { LoopObject j = i; }
        }
        static void IterateForOnListWithoutCountOptimization(List<LoopObject> list)
        {
            for (var i = 0; i < list.Count; i++) { LoopObject j = list[i]; }
        }
        static void IterateForOnListWithCountOptimization(List<LoopObject> list)
        {
            int count = list.Count;
            for (var i = 0; i < count; i++) { LoopObject j = list[i]; }
        }

        static void IterateForeachOnArray(LoopObject[] array)
        {
            foreach (var i in array) { LoopObject j = i; }
        }
        static void IterateForOnArrayWithoutCountOptimization(LoopObject[] array)
        {
            for (var i = 0; i < array.Length; i++) { LoopObject j = array[i]; }
        }
        static void IterateForOnArrayWithCountOptimization(LoopObject[] array)
        {
            int length = array.Length;
            for (var i = 0; i < length; i++) { LoopObject j = array[i]; }
        }

        static void IterateParallelForeachOnList(List<LoopObject> list)
        {
            Parallel.ForEach(list, i => { LoopObject j = i; });
        }
        static void IterateParallelForOnListWithoutCountOptimization(List<LoopObject> list)
        {
            Parallel.For(0, list.Count(), i => { LoopObject j = list[i]; });
        }
        static void IterateParallelForOnListWithCountOptimization(List<LoopObject> list)
        {
            int count = list.Count();
            Parallel.For(0, count, i => { LoopObject j = list[i]; });
        }

        static void IterateParallelForeachOnArray(LoopObject[] array)
        {
            Parallel.ForEach(array, i => { LoopObject j = i; });
        }
        static void IterateParallelForOnArrayWithoutCountOptimization(LoopObject[] array)
        {
            Parallel.For(0, array.Count(), i => { LoopObject j = array[i]; });
        }
        static void IterateParallelForOnArrayWithCountOptimization(LoopObject[] array)
        {
            int count = array.Count();
            Parallel.For(0, count, i => { LoopObject j = array[i]; });
        }
    }
}
