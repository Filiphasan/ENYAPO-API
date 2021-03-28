﻿using Enyapo.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enyapo.Data.Context
{
    public class EnyapoDbContext : IdentityDbContext<UserApp,IdentityRole,string>
    {
        public EnyapoDbContext(DbContextOptions<EnyapoDbContext> options):base(options)
        {
        }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
        public DbSet<UserPost> UserPosts { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }
    }
}