using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Samir_Cabrera.Movies.Entity;

namespace Samir_Cabrera.Movies.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public DbSet<Samir_Cabrera.Movies.Entity.Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Description = "http://sample.com", Like = true, Title = "s" },
                new Movie { Id = 2, Description = "http://sample.com", Like = true, Title = "s" });
            modelBuilder.Entity<Image>().HasData(
                     new Image { Id = 2, MovieId = 2, Url = "s" },
                     new Image { Id = 3, MovieId = 2, Url = "s" },
                     new Image { Id = 1, MovieId = 1, Url = "s" }
                );
        }
    }
}
