using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CentralService.Api.User.DTO.Database;

namespace CentralService.Api.User.DataAccess
{
    public class Context : DbContext
    {
        public DbSet<DeviceProfile> DeviceProfiles { get; }
        public DbSet<GameProfile> GameProfiles { get; }

        public Context() : base(GetDbContextOptions()) { }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            Builder.Entity<Buddy>().HasOne(x => x.Sender).WithMany(x => x.Buddies).HasForeignKey(x => x.SenderId).OnDelete(DeleteBehavior.NoAction);
            Builder.Entity<Buddy>().HasOne(x => x.Recipient).WithMany(x => x.IncomingRequests).HasForeignKey(x => x.RecipientId).OnDelete(DeleteBehavior.NoAction);
        }

        private static DbContextOptions<Context> GetDbContextOptions() => new DbContextOptionsBuilder<Context>().UseSqlServer(Properties.Resources.LocalConnectionString).Options;
    }
}
