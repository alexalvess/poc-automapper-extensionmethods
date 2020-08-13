using poc_automapper_extensionmethod.Case02.Entities;
using poc_automapper_extensionmethod.Case02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace poc_automapper_extensionmethod.Case02.UseCases
{
    public static class ExtensionMethod
    {
        public static User Mapper(this UserModel userModel) =>
            new User(userModel.Id, userModel.BirthDate, userModel.Name, userModel.Score, userModel.Address.Mapper(), userModel.Contacts.Mapper());

        public static Address Mapper(this AddressModel addressModel) =>
            new Address(addressModel.ZipCode, addressModel.Street, addressModel.Number);

        public static Contact Mapper(this ContactModel contactModel) =>
            new Contact(contactModel.ContactType, contactModel.Description);

        public static List<Contact> Mapper(this List<ContactModel> contactModels) =>
            new List<Contact>(contactModels.Select(s => s.Mapper()));
    }
}
