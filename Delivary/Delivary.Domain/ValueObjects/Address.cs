
namespace Delivary.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string City { get; private set; }
        public string Street { get; private set; }

        private Address() { }

        public Address(string city, string street)
        {
            City = city;
            Street = street;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return City;
            yield return Street;
        }
    }
}
