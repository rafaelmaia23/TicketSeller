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
    public class CinemaRepository : Repository<Cinema>, ICinemaRepository
    {
        private readonly AppDbContext _db;

        public CinemaRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public override Cinema GetById(int id)
        {
            return _db.Cinemas.FirstOrDefault(x => x.Id == id);
        }
    }
}
