using poc_automapper_extensionmethod.Case01.Entities;
using poc_automapper_extensionmethod.Case01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace poc_automapper_extensionmethod.Case01
{
    public static class ExtensionMethodMapper
    {
        public static User Mapper(this UserModel userModel) =>
            new User(userModel.Id, userModel.BirthDate, userModel.Name, userModel.Score);

        public static List<User> Mapper(this List<UserModel> usersModel) =>
            new List<User>(usersModel.Select(s => new User(s.Id, s.BirthDate, s.Name, s.Score)));
    }
}
