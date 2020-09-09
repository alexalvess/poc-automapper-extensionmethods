using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace poc_automapper_extensionmethod.Shared
{
    public static class RunCases
    {
        public static void Execute<T>(Func<T> func, string useCase, int quantity)
        {
            Console.WriteLine($"{useCase} with {quantity} object(s)");

            var sw = new Stopwatch();
            var before2 = GC.CollectionCount(2);
            var before1 = GC.CollectionCount(1);
            var before0 = GC.CollectionCount(0);
            sw.Start();

            var resul = func();

            sw.Stop();

            var gen2 = GC.CollectionCount(2) - before2;
            var gen1 = GC.CollectionCount(1) - before1;
            var gen0 = GC.CollectionCount(0) - before0;

            Console.WriteLine($"Total time: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine($"GC Gen #2: {GC.CollectionCount(2) - before2}");
            Console.WriteLine($"GC Gen #1: {GC.CollectionCount(1) - before1}");
            Console.WriteLine($"GC Gen #0: {GC.CollectionCount(0) - before0}\n");
            
            LogRecord.WriteLog(sw.ElapsedMilliseconds, gen2, gen1, gen0, useCase, quantity);

            GC.Collect();
        }
    }
}
