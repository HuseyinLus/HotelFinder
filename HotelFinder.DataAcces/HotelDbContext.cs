﻿using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAcces
{
    internal class HotelDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-TBKO1DI\\SQLEXPRESS; Database=HotelDb4; uid=Huseyin; pwd=1234");
        }

        public DbSet<Hotel>? Hotels { get; set; }
        public DbSet<Car>? Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Car>()
                .HasOne(c => c.hotel)
                .WithMany(h => h.Cars)
                .HasForeignKey(c => c.HotelId);
                
               
               
                



        }
    }
}