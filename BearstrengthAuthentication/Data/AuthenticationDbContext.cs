using BearstrengthAuthentication.Athlete.Entity;
using Microsoft.EntityFrameworkCore;

namespace BearstrengthAuthentication.Data
{
    public class AuthenticationDbContext : DbContext
    {
        public AuthenticationDbContext()
        {
        }

        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options)
        {
        }

        public DbSet<AthleteEntity> Athletes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AthleteEntity>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });
        }
    }
}