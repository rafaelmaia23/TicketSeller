using Microsoft.AspNetCore.Identity;
using TicketSeller.DAL.Data;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Models;

namespace TicketSeller.DAL.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _db;
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _useManager;
    public UnitOfWork(AppDbContext db, SignInManager<User> signInManager, UserManager<User> useManager)
    {
        _db = db;
        _signInManager = signInManager;
        _useManager = useManager;
        Movie = new MovieRepository(_db);
        Genre = new GenreRepository(_db);
        MovieGenre = new MovieGenresRepository(_db);
        Adress = new AdressRepository(_db);
        Cinema = new CinemaRepository(_db);
        MovieSession = new MovieSessionRepository(_db);
        User = new UserRepository(_db, _signInManager, _useManager);
        Ticket = new TicketRepository(_db);
        ShoppingCart = new ShoppingCartRepository(_db);
        Seat = new SeatRepository(_db);
    }
    public IMovieRepository Movie { get; private set; }
    public IGenreRepository Genre { get; private set; }
    public IMovieGenresRepository MovieGenre { get; private set; }
    public IAdressRepository Adress { get; private set; }
    public ICinemaRepository Cinema { get; private set; }
    public IMovieSessionRepository MovieSession { get; private set; }
    public IUserRepository User { get; private set; }
    public ITicketRepository Ticket { get; private set; }
    public IShoppingCartRepository ShoppingCart { get; private set; }
    public ISeatRepository Seat { get; private set; }

    public void Save()
    {
        _db.SaveChanges();
    }
}
