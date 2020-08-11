using AutoMapper;
using poc_automapper_extensionmethod.Case01.Entities;
using poc_automapper_extensionmethod.Case01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace poc_automapper_extensionmethod.Case01.UseCases
{
    public static class AutoMapperOperation
    {
        public static void Start()
        {
            WithMapper<UserModel, User>(InitializeAutomapper(), Mock.GenerateMock().First(), 1);
            WithMapper<List<UserModel>, List<User>>(InitializeAutomapper(), Mock.GenerateMock(1_000), 1_000);
            WithMapper<List<UserModel>, List<User>>(InitializeAutomapper(), Mock.GenerateMock(10_000), 10_000);
            WithMapper<List<UserModel>, List<User>>(InitializeAutomapper(), Mock.GenerateMock(100_000), 100_000);
            WithMapper<List<UserModel>, List<User>>(InitializeAutomapper(), Mock.GenerateMock(1_000_000), 1_000_000);
        }

        public static void WithMapper<TSource, TDestiny>(Mapper mapper, TSource source, int quantity) =>
            RunCases.Execute(() => mapper.Map<TDestiny>(source), "AutoMapper", quantity);

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
