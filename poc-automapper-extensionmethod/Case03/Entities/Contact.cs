using poc_automapper_extensionmethod.Case03.Enum;
using poc_automapper_extensionmethod.Case03.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace poc_automapper_extensionmethod.Case03.Entities
{
    public class Contact
    {
        public Contact(ContactType contactType, string description)
        {
            ContactType = contactType;
            Description = description;
        }

        public Contact()
        {

        }

        public ContactType ContactType { get; set; }

        public string Description { get; set; }

        public static Contact Create(ContactModel contactModel) => new Contact
        {
            ContactType = (ContactType)contactModel.ContactType,
            Description = contactModel.Contact
        };
    }
}
