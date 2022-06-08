using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Services
{
    public class FundooContext : DbContext
    {
        public FundooContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Note> Note { get; set; }
        //public DbSet<Collaborator> Collaborator { get; set; }

        //protected override void
        //OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>()
        //     .HasMany(b => b.Notes)
        //     .WithOne();

        //    modelBuilder.Entity<User>()
        //    .Navigation(b => b.Notes)
        //    .UsePropertyAccessMode(PropertyAccessMode.Property);

        //    modelBuilder.Entity<Collaborator>()
        //        .HasKey(x => new { x.UserId, x.NoteId });

        //}
    }
}
