using poc_automapper_extensionmethod.Case01.Models;
using poc_automapper_extensionmethod.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace poc_automapper_extensionmethod.Case01.Entities
{
    public class User
    {
        public User(int id, DateTime birthDate, string name, double score)
        {
            Id = id;
            BirthDate = birthDate;
            Name = name;
            Score = score;
        }

        public User()
        {

        }

        public int Id { get; set; }

        public DateTime BirthDate { get; set; }

        public string Name { get; set; }

        public double Score { get; set; }

        public static User Create(UserModel user) => new User
        {
            Id = user.Id,
            BirthDate = user.BirthDate,
            Name = user.Name,
            Score = user.Score
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
