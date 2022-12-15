using TicketSeller.DAL.Data;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Models;

namespace TicketSeller.DAL.Repository
{
    public class MovieGenresRepository : Repository<MovieGenre>, IMovieGenresRepository
    {
        private readonly AppDbContext _db;
        public MovieGenresRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(MovieGenre movieGenres)
        {
            _db.MoviesGenres.Update(movieGenres);
        }
    }
}
