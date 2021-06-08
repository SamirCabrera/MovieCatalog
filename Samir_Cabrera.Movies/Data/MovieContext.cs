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
            Guid id1 = Guid.NewGuid();
            Guid id2 = Guid.NewGuid();

            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = id1, Description = "http://sample.com", Like = true, Title = "s" },
                new Movie { Id = id2, Description = "http://sample.com", Like = true, Title = "s" });

            modelBuilder.Entity<Image>().HasData(
                     new Image { Id = Guid.NewGuid(), MovieId = id2, Url = "s" },
                     new Image { Id = Guid.NewGuid(), MovieId = id2, Url = "s" },
                     new Image { Id = Guid.NewGuid(), MovieId = id1, Url = "s" }
                );
        }
    }
}
