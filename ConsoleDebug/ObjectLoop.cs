using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDebug
{
    public static class ObjectLoop
    {
        public static void ObjLoop()
        {
            long iterator = 10000000;
            string l = "";

            Console.Write($"How many loops ( <= {iterator} )?: ");
            l = Console.ReadLine();
            bool test = long.TryParse(l, out iterator);
            if (iterator == 0 || iterator > 10000000)
                iterator = 10000000;

            Console.WriteLine();
            Console.WriteLine($"We will loop {iterator} times");
            Console.WriteLine();

            List<Output> output = new List<Output>();

            List<LoopObject> rows = PopulateLoop(iterator);
            LoopObject[] rowsArray = PopulateArray(iterator);
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
        static List<LoopObject> PopulateLoop(long rows)
        {
            List<LoopObject> objs = new List<LoopObject>();
            for (int i = 0; i < rows; i++)
                objs.Add(new LoopObject { Key = "Key " + i.ToString(), Value = $"Value = " + i.ToString() });
            return objs;
        }
        static LoopObject[] PopulateArray(long rows)
        {
            List<LoopObject> objs = new List<LoopObject>();
            for (int i = 0; i < rows; i++)
                objs.Add(new LoopObject { Key = $"Key {i}", Value = $"Value = {i}" });
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
    }
}
