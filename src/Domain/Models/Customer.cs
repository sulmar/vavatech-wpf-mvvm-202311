using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;

public class Customer : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public string Email { get; set; }
    public Address ShippingAddress { get; set; }
    public bool IsRemoved { get; set; }
}

public class Address : Base
{
    public string City { get; set; }
    public string Street { get; set; }
}
