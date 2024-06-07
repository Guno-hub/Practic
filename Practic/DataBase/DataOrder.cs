using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;

namespace Practic.DataBase
{
    public class DataTest : DbContext
    {
        public DbSet<Zapis> Zapisy { get; set; }

        public DataTest() : base("DBConnection")
        {
            this.Database.Log = Console.Write;
        }
      
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Zapis>().ToTable("Zapisy");
        }
    }
}
