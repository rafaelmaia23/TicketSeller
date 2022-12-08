using Microsoft.EntityFrameworkCore;
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
            builder.Entity<MovieGenres>()
                .HasOne(movieGenres => movieGenres.Movie)
                .WithMany(movie => movie.MovieGenres)
                .HasForeignKey(movieGenres => movieGenres.MovieId);

            builder.Entity<MovieGenres>()
                .HasOne(movieGenres => movieGenres.Genre)
                .WithMany(genre => genre.MovieGenres)
                .HasForeignKey(movieGenres => movieGenres.GenreId);

            builder.Entity<Adress>()
                .HasOne(adress => adress.Cinema)
                .WithOne(cinema => cinema.Adress)
                .HasForeignKey<Cinema>(cinema => cinema.AdressId);

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenres> MoviesGenres { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
    }
}
