using Microsoft.EntityFrameworkCore;
using TicketSeller.DAL.Data;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Models;

namespace TicketSeller.DAL.Repository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        private readonly AppDbContext _db;
        public MovieRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public override Movie GetById(int id)
        {
            return _db.Movies
                .Include(m => m.MovieGenres)
                .ThenInclude(g => g.Genre)
                .FirstOrDefault(x => x.Id == id);
        }

        public override IEnumerable<Movie> GetAll()
        {
            return _db.Movies
                .Include(m => m.MovieGenres)
                .ThenInclude(g => g.Genre)
                .ToList();
        }
    }
}
