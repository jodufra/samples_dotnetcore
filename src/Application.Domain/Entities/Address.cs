using Application.Domain.SeedWork;
using System.Collections.Generic;

namespace Application.Domain.Entities
{
    public class Address : ValueObject
    {
        public static readonly Address Empty = new Address();

        public string Country { get; set; }
        public string District { get; set; }
        public string County { get; set; }
        public string Location { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Door { get; set; }

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
