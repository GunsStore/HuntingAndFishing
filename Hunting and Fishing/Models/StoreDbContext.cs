using System.Security.Principal;

namespace Hunting_and_Fishing.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StoreDbContext : DbContext
    {
        public StoreDbContext()
            : base("name=StoreDbContext")
        {
        }

        public virtual DbSet<Register>Users { get; set; }
        public virtual IPrincipal Register { get; internal set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<Hunting_and_Fishing.Models.LogIn> LogIns { get; set; }
    }
}
