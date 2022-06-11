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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Collaborator>()
                .HasKey(t => new { t.UserId, t.NoteId });
            modelBuilder.Entity<Collaborator>()
                .HasOne(pt => pt.user)
                .WithMany(t => t.collaborators)
                .HasForeignKey(pt => pt.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Collaborator>()
                .HasOne(pt => pt.note)
                .WithMany(t => t.collaborators)
                .HasForeignKey(pt => pt.NoteId)
            .OnDelete(DeleteBehavior.Cascade);

        }
    }
}

}
