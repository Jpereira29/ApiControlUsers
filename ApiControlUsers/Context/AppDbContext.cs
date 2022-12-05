﻿using ApiControlUsers.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiControlUsers.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
    }
}
