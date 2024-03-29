﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TicketSeller.DAL.Data;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Models;

namespace TicketSeller.DAL.Repository;

public class MovieSessionRepository : Repository<MovieSession>, IMovieSessionRepository
{
    private readonly AppDbContext _db;
    public MovieSessionRepository(AppDbContext db) : base(db)
    {
        _db = db;
    }

    public override MovieSession GetById(Expression<Func<MovieSession, bool>> expression)
    {
        return _db.MovieSessions
            .Include(x => x.Movie)
            .Include(x => x.Cinema)
            .FirstOrDefault(expression);
    }

    public override IEnumerable<MovieSession> GetAll()
    {
        return _db.MovieSessions
            .Include(x => x.Movie)
            .Include(x => x.Cinema)
            .ToList();
    }

    public bool Any(Expression<Func<MovieSession, bool>> expression)
    {
        return _db.MovieSessions.Any(expression);
    }
}
