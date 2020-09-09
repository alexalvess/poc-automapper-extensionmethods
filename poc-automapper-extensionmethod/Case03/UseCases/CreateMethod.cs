using poc_automapper_extensionmethod.Case03.Entities;
using poc_automapper_extensionmethod.Case03.Models;
using poc_automapper_extensionmethod.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace poc_automapper_extensionmethod.Case03.UseCases
{
    public static class CreateMethod
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
                RunCases.Execute(() => User.Create(source.First()), "Create Method - Lambda", source.Count);
            else
                RunCases.Execute(() => User.CreateWithLambda(source), "Create Method - Lambda", source.Count);
        }

        private static void WithFor(List<UserModel> source)
        {
            if (source.Count > 1)
                RunCases.Execute(() => User.CreateWithFor(source), "Create Method - For", source.Count);
        }

        private static void WithForeach(List<UserModel> source)
        {
            if (source.Count > 1)
                RunCases.Execute(() => User.CreateWithForeach(source), "Create Method - Foreach", source.Count);
        }

        private static void WithParallelFor(List<UserModel> source)
        {
            if (source.Count > 1)
                RunCases.Execute(() => User.CreateWithParallelFor(source), "Create Method - Parallel For", source.Count);
        }

        private static void WithParallelForeach(List<UserModel> source)
        {
            if (source.Count > 1)
                RunCases.Execute(() => User.CreateWithParallelForeach(source), "Create Method - Parallel Foreach", source.Count);
        }
    }
}
