using Bogus;
using poc_automapper_extensionmethod.Case01.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace poc_automapper_extensionmethod.Case01
{
    public static class Mock
    {
        public static List<UserModel> GenerateMock(int count = 1)
        {
            var user = new Faker<UserModel>()
                .RuleFor(r => r.Id, f => f.Random.Int())
                .RuleFor(r => r.Name, f => f.Name.FullName())
                .RuleFor(r => r.BirthDate, f => f.Date.Past())
                .RuleFor(r => r.Score, f => f.Random.Double())
                .Generate(count);

            return user;
        }
    }
}
