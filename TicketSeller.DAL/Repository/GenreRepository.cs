using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TicketSeller.DAL.Data;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Models;

namespace TicketSeller.DAL.Repository
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        private readonly AppDbContext _db;
        public GenreRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public override Genre GetById(Expression<Func<Genre, bool>> expression)
        {
            return _db.Genres
                .Include(g => g.MovieGenres)
                .ThenInclude(m => m.Movie)
                .FirstOrDefault(expression);
        }

        public override IEnumerable<Genre> GetAll()
        {
            return _db.Genres
                .Include(g => g.MovieGenres)
                .ThenInclude(m => m.Movie)
                .ToList();
        }
    }
}
