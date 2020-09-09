using System.IO;

namespace poc_automapper_extensionmethod
{
    class Program
    {
        static void Main(string[] args)
        {
            const string file = "benchmark.csv";

            if (File.Exists(file))
                File.Delete(file);

            Case01.Run.Start();
            //Case02.Run.Start();
            //Case03.Run.Start();
        }
    }
}
