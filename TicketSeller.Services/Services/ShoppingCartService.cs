using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Dtos.ShoppingCartDto;
using TicketSeller.Models.Models;
using TicketSeller.Services.Services.IServices;

namespace TicketSeller.Services.Services;

public class ShoppingCartService : IShoppingCartService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ShoppingCartService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public Result<ReadShoppingCartDto> AddShoppingCart(CreateShoppingCartDto createShoppingCartDto, string userId)
    {
        if(createShoppingCartDto.Seats.Count != createShoppingCartDto.TicketsCount)
        {
            return Result.Fail("Seats list number and Tickets count number do not match");
        }
        foreach(var seat in createShoppingCartDto.Seats)
        {
            if(seat.IsAvailable == false)
            {
                return Result.Fail($"Seat {seat.Name} is not available");
            }
        }

        ShoppingCart shoppingCart = _mapper.Map<ShoppingCart>(createShoppingCartDto);
        shoppingCart.UserId = Convert.ToInt32(userId);
        return Result.Ok();
    }

    public ReadShoppingCartDto GetShoppingCartById(int id)
    {
        throw new NotImplementedException();
    }
}
