using poc_automapper_extensionmethod.Case02.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace poc_automapper_extensionmethod.Case02.Entities
{
    public class Contact
    {
        public Contact(ContactType contactType, string description)
        {
            ContactType = contactType;
            Description = description;
        }

        public ContactType ContactType { get; set; }

        public string Description { get; set; }
    }
}
