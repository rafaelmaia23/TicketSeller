namespace TicketSeller.DAL.Repository.IRepository;

public interface IUnitOfWork
{
    IMovieRepository Movie { get; }
    IGenreRepository Genre { get; }
    IMovieGenresRepository MovieGenre { get; }
    IAdressRepository Adress { get; }
    ICinemaRepository Cinema { get; }
    IMovieSessionRepository MovieSession { get; }
    void Save();
}
