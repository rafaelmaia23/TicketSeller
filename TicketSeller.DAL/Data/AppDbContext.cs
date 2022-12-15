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
            builder.Entity<MovieGenre>()
                .HasOne(movieGenres => movieGenres.Movie)
                .WithMany(movie => movie.MovieGenres)
                .HasForeignKey(movieGenres => movieGenres.MovieId);

            builder.Entity<MovieGenre>()
                .HasOne(movieGenres => movieGenres.Genre)
                .WithMany(genre => genre.MovieGenres)
                .HasForeignKey(movieGenres => movieGenres.GenreId);

            builder.Entity<Adress>()
                .HasOne(adress => adress.Cinema)
                .WithOne(cinema => cinema.Adress)
                .HasForeignKey<Cinema>(cinema => cinema.AdressId);

            builder.Entity<MovieSession>()
                .HasOne(movieSession => movieSession.Cinema)
                .WithMany(cinema => cinema.MovieSessions)
                .HasForeignKey(movieSession => movieSession.CinemaId);

            builder.Entity<MovieSession>()
                .HasOne(movieSession => movieSession.Movie)
                .WithMany(movie => movie.MovieSessions)
                .HasForeignKey(movieSession => movieSession.MovieId);

            builder.Entity<MovieSession>()
                .HasMany(m => m.Seats)
                .WithOne(s => s.MovieSession)
                .HasForeignKey(s => s.MovieSessionId);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MoviesGenres { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<MovieSession> MovieSessions { get; set; }
        public DbSet<Seat> Seats { get; set; }
    }
}
