using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Hunting_and_Fishing.Models
{
    public class StoreProjectDBContext : DbContext
    {
        public DbSet<UserAccount> UserAccount { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
    }
}