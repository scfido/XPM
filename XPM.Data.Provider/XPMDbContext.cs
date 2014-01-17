using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xunmei.XPM.Data.Provider
{
    public class XPMDbContext : DbContext
    {
        public XPMDbContext()
            : base("MySqlConnection")
        {
            this.Database.CreateIfNotExists();
        }

        public string Name { get; set; }

        public DbSet<UserInfo> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>();
            modelBuilder.Types().Configure(entity => entity.ToTable("xpm_" + entity.ClrType.Name));
            base.OnModelCreating(modelBuilder);
        }
    }
}
