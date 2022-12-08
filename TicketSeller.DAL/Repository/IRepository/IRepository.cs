using System.Linq.Expressions;

namespace TicketSeller.DAL.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Remove(T entity);

    }
}
