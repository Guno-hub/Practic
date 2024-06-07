using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Practic
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("DBConnection")
        {
            this.Database.Log = Console.Write;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Zapis> Zapisy { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Users");

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Zapis>().ToTable("Zapisss");
        }
    }
}
