using Inforce.NET.Common.Entities;
using Inforce.NET.DAL.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Inforce.NET.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ShortedUrlConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }

        public DbSet<User> Users { get; set; } = null!;

        public DbSet<ShortedUrl> ShortedUrls { get; set; } = null!;
    }
}
