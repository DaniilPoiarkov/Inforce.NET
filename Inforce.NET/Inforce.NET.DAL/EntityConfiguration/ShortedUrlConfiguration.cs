using Inforce.NET.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inforce.NET.DAL.EntityConfiguration
{
    internal class ShortedUrlConfiguration : IEntityTypeConfiguration<ShortedUrl>
    {
        public void Configure(EntityTypeBuilder<ShortedUrl> builder)
        {
            builder
                .HasOne(su => su.CreatedBy)
                .WithMany(u => u.OwnedUrls)
                .HasForeignKey(su => su.CreatedById);
        }
    }
}
