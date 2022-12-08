using TicketSeller.Models.Models;

namespace TicketSeller.DAL.Repository.IRepository
{
    public interface IMovieGenresRepository : IRepository<MovieGenres>
    {
        void Update(MovieGenres movieGenres);
    }
}
