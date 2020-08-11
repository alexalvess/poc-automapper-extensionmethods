using System;
using System.Collections.Generic;

namespace poc_automapper_extensionmethod.Case02.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public DateTime BirthDate { get; set; }

        public string Name { get; set; }

        public double Score { get; set; }

        public AddressModel Address { get; set; }

        public List<ContactModel> Contacts { get; set; }
    }
}
