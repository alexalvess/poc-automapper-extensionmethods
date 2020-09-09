using poc_automapper_extensionmethod.Case03.Entities;
using poc_automapper_extensionmethod.Case03.Enum;
using poc_automapper_extensionmethod.Case03.Models;
using poc_automapper_extensionmethod.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace poc_automapper_extensionmethod.Case03.UseCases
{
    public static class ExtensionMethod
    {
        public static User Mapper(this UserModel userModel) =>
            new User(userModel.Id, userModel.BornAt, userModel.Name, userModel.Points, userModel.Location.Mapper(), userModel.ContactList.Mapper());

        private static List<User> Mapper(this List<UserModel> usersModel) =>
            new List<User>(usersModel.Select(s => s.Mapper()));

        public static Address Mapper(this AddressModel addressModel) =>
            new Address(addressModel.Identifier, addressModel.Address.Split(";")[0], addressModel.Address.Split(";")[1]);

        public static Contact Mapper(this ContactModel contactModel) =>
            new Contact((ContactType)contactModel.ContactType, contactModel.Contact);

        public static List<Contact> Mapper(this List<ContactModel> contactModels) =>
            new List<Contact>(contactModels.Select(s => s.Mapper()));

        private static List<User> MapperWithFor(this List<UserModel> users) =>
             GenerateList.WithFor(users, (users) => users.Mapper());

        private static List<User> MapperWithForeach(this List<UserModel> users) =>
             GenerateList.WithForeach(users, (users) => users.Mapper());

        private static List<User> MapperWithParallelFor(this List<UserModel> users) =>
             GenerateList.WithParallelFor(users, (users) => users.Mapper());

        private static List<User> MapperWithParallelForeach(this List<UserModel> users) =>
             GenerateList.WithParallelForeach(users, (users) => users.Mapper());

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
                RunCases.Execute(() => source.First().Mapper(), "ExtensionMethod - Lambda", source.Count);
            else
                RunCases.Execute(() => source.Mapper(), "ExtensionMethod - Lambda", source.Count);
        }

        private static void WithFor(List<UserModel> source)
        {
            if (source.Count > 1)
                RunCases.Execute(() => source.MapperWithFor(), "ExtensionMethod - For", source.Count);
        }

        private static void WithForeach(List<UserModel> source)
        {
            if (source.Count > 1)
                RunCases.Execute(() => source.MapperWithForeach(), "ExtensionMethod - Foreach", source.Count);
        }

        private static void WithParallelFor(List<UserModel> source)
        {
            if (source.Count > 1)
                RunCases.Execute(() => source.MapperWithParallelFor(), "ExtensionMethod - Parallel For", source.Count);
        }

        private static void WithParallelForeach(List<UserModel> source)
        {
            if (source.Count > 1)
                RunCases.Execute(() => source.MapperWithParallelForeach(), "ExtensionMethod - Parallel Foreach", source.Count);
        }
    }
}
