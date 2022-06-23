using zadanie4_Napierala.Consolei.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace zadanie4_Napierala.Consolei
{
    public class BloggingContextFactory : IDesignTimeDbContextFactory<DbEntities>
    {
        public DbEntities CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var optionsBuilder = new DbContextOptionsBuilder<DbEntities>();
            string connectionString = configuration.GetConnectionString("Db");
            optionsBuilder.UseSqlServer(connectionString);

            return new DbEntities(optionsBuilder.Options);
        }
    }
}
