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
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserAppId).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(1024).IsRequired();
            builder.Property(x => x.Location).HasMaxLength(150);
            builder.Property(x => x.Thumbnail).HasMaxLength(300);
            builder.HasOne<UserApp>(x => x.UserApp).WithMany(x => x.Activities).HasForeignKey(x => x.UserAppId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
