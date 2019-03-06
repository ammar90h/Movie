using Movie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Movie.DAL
{
    public class DataContext : DbContext
    {
        public DataContext() :base("Sample")
        {

        }

        public DbSet<Film>Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User>Users { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>()
               .HasMany<Genre>(s => s.Genres)
               .WithMany(c => c.Films)
               .Map(cs =>
               {
                   cs.MapLeftKey("FilmId");
                   cs.MapRightKey("GenreId");
                   cs.ToTable("MovieBase");
               });
        }
    }
}