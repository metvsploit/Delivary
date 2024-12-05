namespace Delivary.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return City;
            yield return Street;
        }
    }
}
