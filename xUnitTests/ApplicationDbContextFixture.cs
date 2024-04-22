using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using psk_fitness.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitTests
{
    public class ApplicationDbContextFixture
    {
        public ApplicationDbContext Context { get; private set; }

        public ApplicationDbContextFixture()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();


            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("InMemoryDbForTesting"));

            var serviceProvider = serviceCollection.BuildServiceProvider();
            Context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            Context.Database.EnsureCreated();

        }
    }
}
