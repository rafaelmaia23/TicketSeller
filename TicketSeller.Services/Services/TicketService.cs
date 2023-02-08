using AutoMapper;
using FluentResults;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Dtos.TicketDto;
using TicketSeller.Models.Models;
using TicketSeller.Services.Services.IServices;

namespace TicketSeller.Services.Services;

public class TicketService : ITicketService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TicketService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Result<ReadTicketDto> GetTicketById(int id, string? userId)
    {
        int userIdInt = Convert.ToInt32(userId);
        Ticket ticket = _unitOfWork.Ticket.GetById(x => x.Id == id);
        if (ticket == null) return null;
        if (ticket.UserId != userIdInt) return Result.Fail("Cannot access another user ticket");
        ReadTicketDto readTicketDto = _mapper.Map<ReadTicketDto>(ticket);
        return Result.Ok(readTicketDto);
    }

    public Result<List<ReadTicketDto>> GetTickets(string? userId)
    {
        int userIdInt = Convert.ToInt32(userId);
        List<Ticket> tickets = _unitOfWork.Ticket.GetAll().Where(x => x.UserId == userIdInt).ToList();
        List<ReadTicketDto> readTicketDtos = _mapper.Map<List<ReadTicketDto>>(tickets);
        return Result.Ok(readTicketDtos);
    }
}
