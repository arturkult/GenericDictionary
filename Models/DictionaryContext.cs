using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dictionaries.Models
{
    public class DictionaryContext : DbContext
    {
        public DbSet<BasicClass> BasicClassSet { get; set; }

        public DbSet<ClassWithDependency> ClassWithDependencySet { get; set; }
        public DbSet<AnotherClass> AnotherClassSet { get; set; }

        public DictionaryContext()
            :base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=DictionaryDB;Integrated Security=true");
            }
        }

        public static DictionaryContext Create()
        {
            return new DictionaryContext();
        }
    }
}
