﻿
namespace Delivary.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; } 

        private Name() { }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}
