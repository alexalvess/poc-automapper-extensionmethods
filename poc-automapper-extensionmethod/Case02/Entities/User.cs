using System;
using System.Collections.Generic;
using System.Text;

namespace poc_automapper_extensionmethod.Case02.Entities
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

        public int Id { get; set; }

        public DateTime BirthDate { get; set; }

        public string Name { get; set; }

        public double Score { get; set; }

        public Address Address { get; set; }

        public IList<Contact> Contacts { get; set; }
    }
}
