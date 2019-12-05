using System;
using BearstrengthApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace BearstrengthApi.Data.Repository
{
    public class BearstrengthDbContext : DbContext
    {
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
