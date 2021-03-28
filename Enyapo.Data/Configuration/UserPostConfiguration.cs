using Enyapo.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enyapo.Data.Configuration
{
    public class UserPostConfiguration : IEntityTypeConfiguration<UserPost>
    {
        public void Configure(EntityTypeBuilder<UserPost> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.Content).IsRequired().HasMaxLength(1024);
        }
    }
}
