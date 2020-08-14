using poc_automapper_extensionmethod.Case02.Entities;
using poc_automapper_extensionmethod.Case02.Models;
using poc_automapper_extensionmethod.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace poc_automapper_extensionmethod.Case02.UseCases
{
    public class CreateMethod
    {

        public static void Start()
        {
            Execution.Execute((i) => WithLambda(Mock.GenerateMock(i)));
            Execution.Execute((i) => WithFor(Mock.GenerateMock(i)));
            Execution.Execute((i) => WithForeach(Mock.GenerateMock(i)));
            Execution.Execute((i) => WithParallelFor(Mock.GenerateMock(i)));
            Execution.Execute((i) => WithParallelForeach(Mock.GenerateMock(i)));
        }

        private static void WithLambda(List<UserModel> source)
        {
            if (source.Count == 1)
                RunCases.Execute(() => User.Create(source.First()), "With Create Method", source.Count);
            else
                RunCases.Execute(() => User.CreateWithLambda(source), "With Lambda", source.Count);
        }

        private static void WithFor(List<UserModel> source)
        {
            if (source.Count > 1)
                RunCases.Execute(() => User.CreateWithFor(source), "With For", source.Count);
        }

        private static void WithForeach(List<UserModel> source)
        {
            if (source.Count > 1)
                RunCases.Execute(() => User.CreateWithForeach(source), "With Foreach", source.Count);
        }

        private static void WithParallelFor(List<UserModel> source)
        {
            if (source.Count > 1)
                RunCases.Execute(() => User.CreateWithParallelFor(source), "With Parallel For", source.Count);
        }

        private static void WithParallelForeach(List<UserModel> source)
        {
            if (source.Count > 1)
                RunCases.Execute(() => User.CreateWithParallelForeach(source), "With Parallel Foreach", source.Count);
        }
    }
}
