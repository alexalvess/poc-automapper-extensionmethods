using AutoMapper;
using poc_automapper_extensionmethod.Case01.Entities;
using poc_automapper_extensionmethod.Case01.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace poc_automapper_extensionmethod.Case01
{
    public static class Run
    {
        public static void RunWithMapper()
        {
            var mapper = InitializeAutomapper();
            var userMock = UserModelMock.GenerateMock();

            var entity = Execute(() => mapper.Map<User>(userMock));
        }

        public static void RunWithListMapper()
        {
            var mapper = InitializeAutomapper();
            var userMock = UserModelMock.GenerateWithManyMock();

            var entity = Execute(() => mapper.Map<List<User>>(userMock));
        }

        public static void RunWithoutMapper()
        {
            var userMock = UserModelMock.GenerateMock();

            var entity = Execute(() => userMock.Mapper());
        }

        public static void RunWithoutMapperList()
        {
            var userMock = UserModelMock.GenerateWithManyMock();

            var entity = Execute(() => userMock.Mapper());
        }

        private static T Execute<T>(Func<T> func)
        {
            var sw = new Stopwatch();
            var before2 = GC.CollectionCount(2);
            var before1 = GC.CollectionCount(1);
            var before0 = GC.CollectionCount(0);
            sw.Start();

            var result = func();

            sw.Stop();

            Console.WriteLine($"Total time: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine($"GC Gen #2: {GC.CollectionCount(2) - before2}");
            Console.WriteLine($"GC Gen #1: {GC.CollectionCount(1) - before1}");
            Console.WriteLine($"GC Gen #0: {GC.CollectionCount(0) - before0}");

            return result;
        }

        private static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserModel, User>();
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
