using System.Linq.Expressions;
using TicketSeller.Models.Models;

namespace TicketSeller.DAL.Repository.IRepository;

public interface IMovieSessionRepository : IRepository<MovieSession>
{
    bool Any(Expression<Func<MovieSession, bool>> expression);
}
