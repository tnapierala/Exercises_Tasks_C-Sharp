using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace zadanie4_Napierala.Consolei.Database
{
    public class DbEntities : DbContext
    {
        public DbEntities(DbContextOptions<DbEntities> options) : base(options)
        {
        }

        protected DbEntities()
        {
        }

        public DbSet<Person> People { get; set; }
    }
}
