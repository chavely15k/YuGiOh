﻿using YuGiOh.Domain.Models;
using YuGiOh.Domain.Configurations;
using Microsoft.EntityFrameworkCore;

namespace YuGiOh.Infrastructure
{
    public class YuGiOhDbContext : DbContext
    {
        public YuGiOhDbContext(DbContextOptions<YuGiOhDbContext> options) : base(options)
        {
        }
        public DbSet<Deck> Decks { get; set; }
        public DbSet<Archetype> Archetypes { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Code> Codes { get; set; }

    }
}