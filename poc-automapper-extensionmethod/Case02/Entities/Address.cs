using poc_automapper_extensionmethod.Case02.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace poc_automapper_extensionmethod.Case02.Entities
{
    public class Address
    {
        public Address(string zipCode, string street, string number)
        {
            ZipCode = zipCode;
            Street = street;
            Number = number;
        }

        public Address()
        {

        }

        public string ZipCode { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public static Address Create(AddressModel addressModel) => new Address
        {
            ZipCode = addressModel.ZipCode,
            Street = addressModel.Street,
            Number = addressModel.Number
        };
    }
}
