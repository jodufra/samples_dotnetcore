using Application.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace Application.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string Country { get; }
        public string District { get; }
        public string County { get; }
        public string Location { get; }
        public string PostalCode { get; }
        public string Street { get; }
        public string Door { get; }

        public Address()
        {
        }

        public Address(string country, string district, string county, string location, string postalCode, string street, string door)
        {
            Country = country;
            District = district;
            County = county;
            Location = location;
            PostalCode = postalCode;
            Street = street;
            Door = door;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Country;
            yield return District;
            yield return County;
            yield return Location;
            yield return PostalCode;
            yield return Street;
            yield return Door;
        }
    }
}
