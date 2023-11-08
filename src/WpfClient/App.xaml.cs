using Bogus;
using Domain.Abstractions;
using Domain.Models;
using Infrastructure;
using Infrastructure.Fakers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ViewModels;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public new static App Current => (App)Application.Current;

        public IServiceProvider Services { get; }

        public App()
        {
            Services = ConfigureServices();

            this.InitializeComponent();
        }

        private IServiceProvider ConfigureServices()
        {
            // Install-Package Microsoft.Extensions.DependencyInjection
            var services = new ServiceCollection();

            services.AddSingleton<CustomersViewModel>();
            services.AddSingleton<ICustomerRepository, InMemoryCustomerRepository>();
            services.AddSingleton<Faker<Customer>, CustomerFaker>();
            services.AddSingleton<IEnumerable<Customer>>(sp =>
            {
                var faker = sp.GetRequiredService<Faker<Customer>>();

                return faker.Generate(100);
            });

            return services.BuildServiceProvider();


        }
    }
}
