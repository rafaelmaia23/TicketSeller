using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TicketSeller.DAL.Data;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Models;

namespace TicketSeller.DAL.Repository;

public class AdressRepository : Repository<Adress>, IAdressRepository
{
    private readonly AppDbContext _db;

    public AdressRepository(AppDbContext db) : base(db)
    {
        _db = db;
    }

    public override Adress? GetById(Expression<Func<Adress, bool>> expression)
    {
        return _db.Adresses
            .Include(a => a.Cinema)
            .FirstOrDefault(expression);
    }

    public override IEnumerable<Adress> GetAll()
    {
        return _db.Adresses
            .Include(a => a.Cinema)
            .ToList();
    }
}
