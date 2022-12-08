namespace TicketSeller.DAL.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IMovieRepository Movie { get; }
        IGenreRepository Genre { get; }
        IMovieGenresRepository MovieGenres { get; }
        IAdressRepository Adress { get; }
        ICinemaRepository Cinema { get; }
        void Save();
    }
}
