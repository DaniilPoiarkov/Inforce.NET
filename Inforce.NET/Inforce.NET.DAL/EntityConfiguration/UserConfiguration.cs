using Inforce.NET.Common.Entities;
using Inforce.NET.Common.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inforce.NET.DAL.EntityConfiguration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var users = new List<User>()
            {
                new()
                {
                    Id = 1,
                    Login = "admin",
                    Password = "admin",
                    Role = UserRole.Admin,
                    FullName = "Admin Admin",
                },
                new()
                {
                    Id = 2,
                    Login = "guest",
                    Password = "guest",
                    Role = UserRole.Ordinary,
                    FullName = "Guest Guest",
                },
            };
            builder.HasData(users);
        }
    }
}
