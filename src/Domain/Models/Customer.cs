using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;

public partial class Customer : BaseEntity
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FullName))]
    private string firstName;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FullName))]
    private string lastName;
    public string FullName => $"{FirstName} {LastName}";
    public string Email { get; set; }
    public Address ShippingAddress { get; set; }

    [ObservableProperty]
    private bool isRemoved;
}

public class Address : Base
{
    public string City { get; set; }
    public string Street { get; set; }
}
