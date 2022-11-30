﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSeller.DAL.Data;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Models;

namespace TicketSeller.DAL.Repository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        private readonly AppDbContext _db;
        public MovieRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}