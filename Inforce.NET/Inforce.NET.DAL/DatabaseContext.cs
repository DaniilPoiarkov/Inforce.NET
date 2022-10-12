using Inforce.NET.Common.Entities;
using Inforce.NET.DAL.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inforce.NET.DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public DbSet<ShortedUrl> ShortedUrls { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ShortedUrlConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
