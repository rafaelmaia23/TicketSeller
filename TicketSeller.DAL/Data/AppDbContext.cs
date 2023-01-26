using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TicketSeller.Models.Models;

namespace TicketSeller.DAL.Data;

public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    private readonly IConfiguration _config;
    public AppDbContext(DbContextOptions<AppDbContext> opt, IConfiguration config) : base(opt)
    {
        _config = config;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

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

        User admin = new User
        {
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            Email = "admin@admin.com",
            NormalizedEmail = "ADMIN@ADMIN.COM",
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString(),
            Id = 99999
        };

        PasswordHasher<User> hasher = new PasswordHasher<User>();

        admin.PasswordHash = hasher.HashPassword(admin, _config.GetValue<string>("admininfo:password"));

        builder.Entity<User>().HasData(admin);

        builder.Entity<IdentityRole<int>>().HasData(
            new IdentityRole<int>
            {
                Id = 99999,
                Name = "admin",
                NormalizedName = "ADMIN"
            }
        );

        builder.Entity<IdentityRole<int>>().HasData(
            new IdentityRole<int>
            {
                Id = 99998,
                Name = "client",
                NormalizedName = "CLIENT"
            }
        );

        builder.Entity<IdentityUserRole<int>>().HasData(
            new IdentityUserRole<int>
            {
                RoleId = 99999,
                UserId = 99999
            }
        );
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<MovieGenre> MoviesGenres { get; set; }
    public DbSet<Adress> Adresses { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<MovieSession> MovieSessions { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
}
