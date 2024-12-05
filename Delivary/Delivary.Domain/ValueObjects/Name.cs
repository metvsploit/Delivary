namespace Delivary.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}
