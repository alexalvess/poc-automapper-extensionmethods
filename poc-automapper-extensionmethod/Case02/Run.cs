using AutoMapper;
using Bogus;
using poc_automapper_extensionmethod.Case02.Entities;
using poc_automapper_extensionmethod.Case02.Enum;
using poc_automapper_extensionmethod.Case02.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace poc_automapper_extensionmethod.Case02
{
    public static class Run
    {
        public static void Start()
        {
            Console.WriteLine("CASE 02");

            RunCases.WithMapper<UserModel, User>(InitializeAutomapper(), GenerateMock().First(), 1); // 26ms | 0 gen2 | 0 gen1 | 0 gen0
            RunCases.WithMapper<List<UserModel>, List<User>>(InitializeAutomapper(), GenerateMock(1_000), 1_000); // 12ms | 1 gen2 | 1 gen1 | 1 gen0
            RunCases.WithMapper<List<UserModel>, List<User>>(InitializeAutomapper(), GenerateMock(10_000), 10_000); // 15ms | 0 gen2 | 0 gen1 | 1 gen0
            RunCases.WithMapper<List<UserModel>, List<User>>(InitializeAutomapper(), GenerateMock(100_000), 100_000); // 202ms | 6 gen2 | 6 gen1 | 15 gen0
            RunCases.WithMapper<List<UserModel>, List<User>>(InitializeAutomapper(), GenerateMock(1_000_000), 1_000_000); // 2193ms | 2 gen2 | 45 gen1 | 122 gen0

            WithoutMapper(GenerateMock(1));
            WithoutMapper(GenerateMock(1_000));
            WithoutMapper(GenerateMock(10_000));
            WithoutMapper(GenerateMock(100_000));
            WithoutMapper(GenerateMock(1_000_000));

            WithoutMapperAndWithoutLambda(GenerateMock(1_000));
            WithoutMapperAndWithoutLambda(GenerateMock(10_000));
            WithoutMapperAndWithoutLambda(GenerateMock(100_000));
            WithoutMapperAndWithoutLambda(GenerateMock(1_000_000));
        }

        private static void WithoutMapper(List<UserModel> source)
        {
            if(source.Count == 1)
                RunCases.Execute(() => source.First().Mapper(), "Without AutoMapper", source.Count);
            else
                RunCases.Execute(() => source.Mapper(), "Without AutoMapper", source.Count);
        }

        private static void WithoutMapperAndWithoutLambda(List<UserModel> source)
        {
            if (source.Count == 1)
                RunCases.Execute(() => source.First().Mapper(), "Without AutoMapper and without lambda", source.Count);
            else
                RunCases.Execute(() => source.MapperWithoutLambda(), "Without AutoMapper and without lambda", source.Count);
        }

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

        private static List<UserModel> GenerateMock(int count = 1)
        {
            var address = new Faker<AddressModel>()
                .RuleFor(r => r.ZipCode, f => f.Address.ZipCode())
                .RuleFor(r => r.Street, f => f.Address.StreetAddress())
                .RuleFor(r => r.Number, f => f.Address.BuildingNumber())
                .Generate();

            var contacts = new Faker<ContactModel>()
                .RuleFor(r => r.ContactType, f => (ContactType)f.Random.Int(0, 2))
                .RuleFor(r => r.Description, f => f.Phone.PhoneNumber())
                .Generate(10);

            var user = new Faker<UserModel>()
                .RuleFor(r => r.Id, f => f.Random.Int())
                .RuleFor(r => r.Name, f => f.Name.FullName())
                .RuleFor(r => r.BirthDate, f => f.Date.Past())
                .RuleFor(r => r.Score, f => f.Random.Double())
                .RuleFor(r => r.Address, f => address)
                .RuleFor(r => r.Contacts, f => contacts)
                .Generate(count);

            return user;
        }
    }
}
