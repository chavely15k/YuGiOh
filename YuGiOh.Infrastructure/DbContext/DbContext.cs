﻿using YuGiOh.Domain.Models;
using YuGiOh.Domain.Configurations;
using Microsoft.EntityFrameworkCore;

namespace YuGiOh.Infrastructure
{
    public class YuGiOhDbContext : DbContext
    {
        public YuGiOhDbContext(DbContextOptions<YuGiOhDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new CodeConfiguration());
            builder
                .ApplyConfiguration(new RoleConfiguration());
            builder
                .ApplyConfiguration(new UserConfiguration());
            builder
                .ApplyConfiguration(new UserRoleConfiguration());
        }
        public DbSet<Code> Codes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UsersRole { get; set; }
    }
}