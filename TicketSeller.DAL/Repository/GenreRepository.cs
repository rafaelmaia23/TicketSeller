using Microsoft.EntityFrameworkCore;
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
        public override Genre GetById(int id)
        {
            return _db.Genres
                .Include(g => g.MovieGenres)
                .ThenInclude(m => m.Movie)
                .FirstOrDefault(x => x.Id == id);
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
