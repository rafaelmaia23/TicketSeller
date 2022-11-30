using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSeller.Models.Models;

namespace TicketSeller.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<MovieGenres>()
            //    .HasOne(movie => movie.Movie)
            //    .WithMany(movieGenres => movieGenres.MovieGenres)
            //    .HasForeignKey(movieId => movieId.MovieId);
            //builder.Entity<MovieGenres>()
            //    .HasOne(genre => genre.Genre)
            //    .WithMany(movieGenres => movieGenres.MovieGenres)
            //    .HasForeignKey(genreId => genreId.GenreId);
            builder.Entity<MovieGenres>()
                .HasOne(movieGenres => movieGenres.Movie)
                .WithMany(movie => movie.MovieGenres)
                .HasForeignKey(movieGenres => movieGenres.MovieId);
            builder.Entity<MovieGenres>()
                .HasOne(movieGenres => movieGenres.Genre)
                .WithMany(genre => genre.MovieGenres)
                .HasForeignKey(movieGenres => movieGenres.GenreId);
                
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenres> MoviesGenres { get; set; }
    }
}
