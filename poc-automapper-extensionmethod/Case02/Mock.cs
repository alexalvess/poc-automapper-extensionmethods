using Bogus;
using poc_automapper_extensionmethod.Case02.Enum;
using poc_automapper_extensionmethod.Case02.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace poc_automapper_extensionmethod.Case02
{
    public static class Mock
    {
        public static List<UserModel> GenerateMock(int count = 1)
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
