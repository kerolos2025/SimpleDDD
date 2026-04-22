using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public record Address
    {
        public string Street { get; init; }
        public string City { get; init; }
        public string ZipCode { get; init; }

        private Address(string street, string city, string zipCode)
        {
            Street = street;
            City = city;
            ZipCode = zipCode;
        }

        public static Address Create(string street, string city, string zipCode)
        {
            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("Invalid street");
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("Invalid city");
            if (string.IsNullOrWhiteSpace(zipCode))
                throw new ArgumentException("Invalid zip code");

            return new Address(street, city, zipCode);
        }
    }
}
