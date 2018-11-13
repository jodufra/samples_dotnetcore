using Application.Domain.SeedWork;
using System.Collections.Generic;

namespace Application.Domain.Entities
{
    public class Phone : ValueObject
    {
        public static readonly Phone Empty = new Phone();

        public string Prefix { get; set; }
        public string Number { get; set; }

        public Phone()
        {
        }

        public Phone(string prefix, string number)
        {
            Prefix = prefix;
            Number = number;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Prefix;
            yield return Number;
        }
    }
}
