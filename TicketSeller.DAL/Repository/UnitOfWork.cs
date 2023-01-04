using Microsoft.AspNetCore.Identity;
using TicketSeller.DAL.Data;
using TicketSeller.DAL.Repository.IRepository;

namespace TicketSeller.DAL.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _db;
    private readonly SignInManager<IdentityUser<int>> _signInManager;
    public UnitOfWork(AppDbContext db, SignInManager<IdentityUser<int>> signInManager)
    {
        _db = db;
        _signInManager = signInManager;
        Movie = new MovieRepository(_db);
        Genre = new GenreRepository(_db);
        MovieGenre = new MovieGenresRepository(_db);
        Adress = new AdressRepository(_db);
        Cinema = new CinemaRepository(_db);
        MovieSession = new MovieSessionRepository(_db);
        User = new UserRepository(_db, _signInManager);       
    }
    public IMovieRepository Movie { get; private set; }
    public IGenreRepository Genre { get; private set; }
    public IMovieGenresRepository MovieGenre { get; private set; }
    public IAdressRepository Adress { get; private set; }
    public ICinemaRepository Cinema { get; private set; }
    public IMovieSessionRepository MovieSession { get; private set; }
    public IUserRepository User { get; private set; }

    public void Save()
    {
        _db.SaveChanges();
    }
}
