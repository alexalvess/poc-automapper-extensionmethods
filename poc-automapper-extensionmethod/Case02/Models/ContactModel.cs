using poc_automapper_extensionmethod.Case02.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace poc_automapper_extensionmethod.Case02.Models
{
    public class ContactModel
    {
        public ContactType ContactType { get; set; }

        public string Description { get; set; }
    }
}
