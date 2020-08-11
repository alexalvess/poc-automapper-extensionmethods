using System;
using System.Collections.Generic;
using System.Text;

namespace poc_automapper_extensionmethod.Case01.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public DateTime BirthDate { get; set; }

        public string Name { get; set; }

        public double Score { get; set; }
    }
}
