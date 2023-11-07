using Bogus;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Fakers;

// dotnet add package Bogus
public class CustomerFaker : Faker<Customer>
{
    public CustomerFaker()
    {
        StrictMode(true);
        RuleFor(p => p.Id, f => f.IndexFaker);
        RuleFor(p => p.FirstName, f => f.Person.FirstName);
        RuleFor(p => p.LastName, f => f.Person.LastName);
        RuleFor(p=>p.Email, (f, customer) => $"{customer.FirstName}.{customer.LastName}@domain.com" );
        Ignore(p => p.ShippingAddress);
        RuleFor(p=>p.IsRemoved, f=>f.Random.Bool(0.3f));
    }
}
