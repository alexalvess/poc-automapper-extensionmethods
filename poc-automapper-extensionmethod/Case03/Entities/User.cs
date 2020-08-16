using poc_automapper_extensionmethod.Case03.Models;
using poc_automapper_extensionmethod.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace poc_automapper_extensionmethod.Case03.Entities
{
    public class User
    {
        public User(int id, DateTime birthDate, string name, double score, Address address, List<Contact> contacts)
        {
            Id = id;
            BirthDate = birthDate;
            Name = name;
            Score = score;
            Address = address;
            Contacts = contacts;
        }

        public User()
        {

        }

        public int Id { get; set; }

        public DateTime BirthDate { get; set; }

        public string Name { get; set; }

        public double Score { get; set; }

        public Address Address { get; set; }

        public IList<Contact> Contacts { get; set; }

        public static User Create(UserModel userModel) => new User
        {
            Id = userModel.Id,
            Name = userModel.Name,
            Score = userModel.Points,
            BirthDate = userModel.BornAt,
            Address = Address.Create(userModel.Location),
            Contacts = userModel.ContactList.Select(s => Contact.Create(s)).ToList()
        };

        public static List<User> CreateWithLambda(List<UserModel> users) =>
            GenerateList.WithLambda(users, (user) => Create(user));

        public static List<User> CreateWithFor(List<UserModel> users) =>
            GenerateList.WithFor(users, (user) => Create(user));

        public static List<User> CreateWithForeach(List<UserModel> users) =>
            GenerateList.WithForeach(users, (user) => Create(user));

        public static List<User> CreateWithParallelFor(List<UserModel> users) =>
            GenerateList.WithParallelFor(users, (user) => Create(user));

        public static List<User> CreateWithParallelForeach(List<UserModel> users) =>
            GenerateList.WithParallelForeach(users, (user) => Create(user));
    }
}
