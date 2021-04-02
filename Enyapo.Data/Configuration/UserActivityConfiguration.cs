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
    public class UserActivityConfiguration : IEntityTypeConfiguration<UserActivity>
    {
        public void Configure(EntityTypeBuilder<UserActivity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserAppId).IsRequired();
            builder.Property(x => x.ActivityId).IsRequired();
            builder.HasOne<UserApp>(x => x.UserApp).WithMany(x => x.UserActivities).HasForeignKey(x => x.UserAppId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Activity>(x => x.Activity).WithMany(x => x.UserActivities).HasForeignKey(x => x.ActivityId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
