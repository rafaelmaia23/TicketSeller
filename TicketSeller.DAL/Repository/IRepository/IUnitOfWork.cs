using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSeller.DAL.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IMovieRepository Movie { get; }
        IGenreRepository Genre { get; }
        IMovieGenresRepository MovieGenres { get; }
        void Save();
    }
}
