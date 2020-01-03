
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using WhatFlix.Api.Model;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using FileContextCore;

namespace WhatFlix.DataAccessLayer
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies {get; set;}
        public DbSet<Credit> Credits {get; set;}
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var a = 5;
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>().ToTable("Movies");
            modelBuilder.Entity<Movie>().HasKey(p=> p.Id);
        
            modelBuilder.Entity<Credit>().ToTable("Credits");
            modelBuilder.Entity<Credit>().HasKey(p => p.Id);
            //modelBuilder.Entity<Credit>().HasMany(p => p);
            //modelBuilder.Entity<Credit>().Property(p => p.Crews);
        
            modelBuilder.Entity<Movie>().HasData(Cache.Movies_cache);
            modelBuilder.Entity<Credit>().HasData(Cache.Credits_cache);
            //Movies.AddRange(Cache.Movies_cache);
            
        }
    }
}