using Microsoft.EntityFrameworkCore;
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
    public class AdressRepository : Repository<Adress>, IAdressRepository
    {
        private readonly AppDbContext _db;

        public AdressRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public override IEnumerable<Adress> GetAll()
        {
            return _db.Adresses
                .ToList();
        }
    }
}
