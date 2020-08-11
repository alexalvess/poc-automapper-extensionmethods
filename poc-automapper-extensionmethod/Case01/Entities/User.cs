using System;
using System.Collections.Generic;
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

        public int Id { get; set; }

        public DateTime BirthDate { get; set; }

        public string Name { get; set; }

        public double Score { get; set; }
    }
}
