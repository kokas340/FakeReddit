﻿using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfcDataAccess
{
    public class RedditContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = ../EfcDataAccess/Reddit.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasKey(post => post.Id);
            modelBuilder.Entity<User>().HasKey(user => user.Id);
            modelBuilder.Entity<Post>().Property(post => post.Title).HasMaxLength(20);
        }
    }
}
