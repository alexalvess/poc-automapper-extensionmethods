using AutoMapper;
using poc_automapper_extensionmethod.Case02.Entities;
using poc_automapper_extensionmethod.Case02.Models;
using poc_automapper_extensionmethod.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace poc_automapper_extensionmethod.Case02.UseCases
{
    public static class AutoMapperOperation
    {
        public static void Start()
        {
            Execution.Execute((i) => {
                if (i == 1)
                    WithMapper<UserModel, User>(InitializeAutomapper(), Mock.GenerateMock().First(), i);
                else
                    WithMapper<List<UserModel>, List<User>>(InitializeAutomapper(), Mock.GenerateMock(i), i);
            });
        }

        public static void WithMapper<TSource, TDestiny>(Mapper mapper, TSource source, int quantity) =>
            RunCases.Execute(() => mapper.Map<TDestiny>(source), "AutoMapper", quantity);

        private static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ContactModel, Contact>();
                cfg.CreateMap<AddressModel, Address>();
                cfg.CreateMap<UserModel, User>();
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
