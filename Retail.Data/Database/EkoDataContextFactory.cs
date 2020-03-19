using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Retail.Data.Database
{
    public class EkoDataContextFactory : IDesignTimeDbContextFactory<EkoDataContext>
    {
        public EkoDataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("Database.json").Build();
            var connectionString = configuration.GetConnectionString("EkoDatabase");
            optionsBuilder.UseSqlServer(connectionString);
            return new EkoDataContext(optionsBuilder.Options);

        }
    }
}