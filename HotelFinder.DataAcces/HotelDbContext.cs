﻿using Domain;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity;
using Domain.Entities;

namespace HotelFinder.DataAcces
{
    internal class dbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-TBKO1DI\\SQLEXPRESS; Database=HotelDb4; uid=Huseyin; pwd=1234");
        }

        public DbSet<Hotel>? Hotels { get; set; }
        public DbSet<Car>? Cars { get; set; }
        public DbSet<Register>? Registers { get; set; }
        public DbSet<Login>? Logins { get; set; }
        public DbSet<RefreshTokenEntities>? RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<RefreshTokenEntities>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<RefreshTokenEntities>()
                .HasOne(r => r.Logins)
                .WithMany(l => l.RefreshTokens)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Kullanıcı silindiğinde ilişkili tokenlar da silinir

            base.OnModelCreating(modelBuilder);
        }
    }
}