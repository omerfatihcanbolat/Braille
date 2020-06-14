﻿using Braille.DAL.Models;
using System.Data.Entity;


namespace Braille.DAL.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("name=connectionString")
        {

        }

        public DbSet<Kelimeler> Kelimeler { get; set; }
        public DbSet<Skor> Skorlar { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Skor>().Property(dp => dp.SkorId).IsRequired();
            //modelBuilder.Entity<Kelimeler>().Property(dp => dp.KelimeId).IsRequired();


        }
    }



}
