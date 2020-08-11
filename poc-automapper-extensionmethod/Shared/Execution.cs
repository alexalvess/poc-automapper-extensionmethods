using System;
using System.Collections.Generic;
using System.Text;

namespace poc_automapper_extensionmethod.Shared
{
    public static class Execution
    {
        public static void Execute(Action<int> action)
        {
            for (int i = 1; i <= 1_000_000; i = i * 10)
                action(i);
        }
    }
}
