using TicketSeller.Models.Models;

namespace TicketSeller.DAL.Repository.IRepository
{
    public interface IMovieGenresRepository : IRepository<MovieGenre>
    {
        void Update(MovieGenre movieGenres);
    }
}
