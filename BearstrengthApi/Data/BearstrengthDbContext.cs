using BearstrengthApi.User.Entity;
using Microsoft.EntityFrameworkCore;

namespace BearstrengthApi.Data
{
    public class BearstrengthDbContext : DbContext
    {
        public BearstrengthDbContext()
        {
        }

        public BearstrengthDbContext(DbContextOptions<BearstrengthDbContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
    }
}