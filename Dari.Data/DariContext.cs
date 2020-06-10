using Dari.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Dari.Data
{
    public class DariContext: DbContext
    {
        public DariContext() : base("name=MaChaine")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DariContext>());
            // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DariContext>());
        }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        }
}
