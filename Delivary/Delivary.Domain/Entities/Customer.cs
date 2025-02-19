﻿using Delivary.Domain.ValueObjects;

namespace Delivary.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public Name Name { get; set; } 
        public List<Order> Orders { get; set; } = [];
    }
}
