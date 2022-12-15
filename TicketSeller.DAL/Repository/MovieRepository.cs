using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
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

        public override Movie GetById(Expression<Func<Movie, bool>> expression)
        {
            return _db.Movies
                .Include(m => m.MovieGenres)
                .ThenInclude(g => g.Genre)
                .FirstOrDefault(expression);
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
