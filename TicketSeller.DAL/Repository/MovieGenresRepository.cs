using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSeller.DAL.Data;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Models;

namespace TicketSeller.DAL.Repository
{
    public class MovieGenresRepository : Repository<MovieGenres>, IMovieGenresRepository
    {
        private readonly AppDbContext _db;
        public MovieGenresRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
