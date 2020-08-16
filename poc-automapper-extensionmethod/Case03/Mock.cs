using Bogus;
using poc_automapper_extensionmethod.Case03.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace poc_automapper_extensionmethod.Case03
{
    public static class Mock
    {
        public static List<UserModel> GenerateMock(int count = 1)
        {
            var address = new Faker<AddressModel>()
                .RuleFor(r => r.Identifier, f => f.Address.ZipCode())
                .RuleFor(r => r.Address, f => f.Address.StreetAddress() + ";" + f.Address.BuildingNumber())
                .Generate();

            var contacts = new Faker<ContactModel>()
                .RuleFor(r => r.ContactType, f => f.Random.Int(0, 2))
                .RuleFor(r => r.Contact, f => f.Phone.PhoneNumber())
                .Generate(10);

            var user = new Faker<UserModel>()
                .RuleFor(r => r.Id, f => f.Random.Int())
                .RuleFor(r => r.Name, f => f.Name.FullName())
                .RuleFor(r => r.BornAt, f => f.Date.Past())
                .RuleFor(r => r.Points, f => f.Random.Double())
                .RuleFor(r => r.Location, f => address)
                .RuleFor(r => r.ContactList, f => contacts)
                .Generate(count);

            return user;
        }
    }
}
