using Bogus;
using Domain.Abstractions;
using Domain.Models;
using Infrastructure;
using Infrastructure.Fakers;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ViewModels;
using WpfClient.Services;
using WpfClient.Views;

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

            var navigation = Services.GetService<INavigationService>();

            navigation.RegisterRoute("Customers", typeof(CustomersView));
            navigation.RegisterRoute("Items", typeof(ItemsView));

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

            services.AddSingleton<IMessageService, FakeMessageService>();
            services.AddSingleton<IMessageService, RealMessageService>();

            services.AddSingleton<ShellViewModel>();
            services.AddSingleton<INavigationService, FrameNavigationService>();

            services.AddSingleton<CustomersView>();
            services.AddSingleton<ItemsView>();

            return services.BuildServiceProvider();


        }
    }
}
