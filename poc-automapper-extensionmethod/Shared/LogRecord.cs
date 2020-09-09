using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace poc_automapper_extensionmethod.Shared
{
    public static class LogRecord
    {
        public static void WriteLog(long time, int g2, int g1, int g0, string useCase, int quantity)
        {
            const string file = "benchmark.csv";
            const string header = "Use Case;Elapsed Time;GC Gen 2;GC Gen 1;GC Gen 0";

            if (!File.Exists(file))
                File.Create(file).Close();

            if (!File.ReadLines(file).Any(l => string.Equals(l, header)))
                File.AppendAllText(file, header + Environment.NewLine);

            if(quantity == 1 || quantity == 10)
                File.AppendAllText(file, useCase + Environment.NewLine);

            var record = $"With {quantity};{time}ms;{g2};{g1};{g0}";

            File.AppendAllText(file, record + Environment.NewLine);
        }
    }
}
