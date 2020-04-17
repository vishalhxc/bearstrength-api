using BearstrengthEnrollmentApi.User.Entity;
using Microsoft.EntityFrameworkCore;

namespace BearstrengthEnrollmentApi.Data
{
    public class EnrollmentDbContext : DbContext
    {
        public EnrollmentDbContext()
        {
        }

        public EnrollmentDbContext(DbContextOptions<EnrollmentDbContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });
        }
    }
}