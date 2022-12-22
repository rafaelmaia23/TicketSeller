using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TicketSeller.DAL.Data;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Models;

namespace TicketSeller.DAL.Repository;

public class CinemaRepository : Repository<Cinema>, ICinemaRepository
{
    private readonly AppDbContext _db;

    public CinemaRepository(AppDbContext db) : base(db)
    {
        _db = db;
    }
    public override Cinema GetById(Expression<Func<Cinema, bool>> expression)
    {
        return _db.Cinemas
            .Include(a => a.Adress)
            .FirstOrDefault(expression);
    }

    public override IEnumerable<Cinema> GetAll()
    {
        return _db.Cinemas
            .Include(a => a.Adress)
            .ToList();
    }
}
