using poc_automapper_extensionmethod.Case02.Entities;
using poc_automapper_extensionmethod.Case02.Models;
using System.Collections.Generic;
using System.Linq;

namespace poc_automapper_extensionmethod.Case02
{
    public static class ExtensionMethodMapper
    {
        public static User Mapper(this UserModel userModel) =>
            new User(userModel.Id, userModel.BirthDate, userModel.Name, userModel.Score, userModel.Address.MapperAddress(), userModel.Contacts.MapperContact());

        public static List<User> Mapper(this List<UserModel> usersModel) =>
            new List<User>(usersModel.Select(s => s.Mapper()));

        public static List<User> MapperWithoutLambda(this List<UserModel> users)
        {
            var list = new List<User>(users.Count);

            for (int i = 0; i < users.Count; i++)
                list.Add(users[i].Mapper());

            return list;
        }

        private static Address MapperAddress(this AddressModel address) =>
            new Address(address.ZipCode, address.Street, address.Number);

        private static List<Contact> MapperContact(this List<ContactModel> contacts) =>
            new List<Contact>(contacts.Select(s => new Contact(s.ContactType, s.Description)));
    }
}
