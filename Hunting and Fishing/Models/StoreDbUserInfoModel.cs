using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hunting_and_Fishing.Models
{
    public class StoreDbUserInfoModel : DbContext
    {
        public StoreDbUserInfoModel()
            : base("name=StoreDbContext")
        {
        }

        public virtual DbSet<UserInfoModel> UserInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}