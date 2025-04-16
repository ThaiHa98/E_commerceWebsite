using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Infrastructure.Persistence
{
    public class Website_Selling_Movie_Tickets_DbContextFactory : IDesignTimeDbContextFactory<E_commerceWebsiteDbContext>
    {
        public E_commerceWebsiteDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<E_commerceWebsiteDbContext>();
            var connectionString = configuration.GetSection("DatabaseSettings:ConnectionString").Value;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("ConnectionString", "Connection string is not configured.");
            }

            optionsBuilder.UseSqlServer(connectionString);
            return new E_commerceWebsiteDbContext(optionsBuilder.Options);
        }
    }
}
