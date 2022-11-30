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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Movie = new MovieRepository(_db);
            Genre = new GenreRepository(_db);
            MovieGenres = new MovieGenresRepository(_db);
        }
        public IMovieRepository Movie { get; private set; }
        public IGenreRepository Genre { get; private set; }
        public IMovieGenresRepository MovieGenres { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
