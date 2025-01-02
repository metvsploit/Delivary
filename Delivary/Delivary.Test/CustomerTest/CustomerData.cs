using Delivary.Domain.Entities;
using Delivary.Domain.ValueObjects;

namespace Delivary.Test.CustomerTest
{
    public static class CustomerData
    {
        public static Guid Id = Guid.NewGuid();
        private static List<Customer> _customers = new();

        public static List<Customer> Get()
        {
            if (_customers.Count > 0)
            {
                return _customers;
            }

            for (int i = 1; i <= 5; i++)
            {
                var customer = new Customer
                {
                    Name = new Name("Name" + i, "LastName" + i),
                };

                _customers.Add(customer);
            }

            _customers[0].Id = Id;

            return _customers;
        }
    }
}
