﻿using Domain.Models;
using Infrastructure.Db.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Db
{
    public class OrderDbContext : DbContext, IDbContext
    {
        public DbSet<Order> Orders { get; set; }

        public OrderDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}