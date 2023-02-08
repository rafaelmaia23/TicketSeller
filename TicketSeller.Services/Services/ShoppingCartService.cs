using AutoMapper;
using FluentResults;
using Stripe;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Dtos.ShoppingCartDto;
using TicketSeller.Models.Models;
using TicketSeller.Models.Stripe;
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
        MovieSession movieSession = _unitOfWork.MovieSession.GetById(x => x.Id == createShoppingCartDto.MovieSessionId);
        if (movieSession == null) return Result.Fail("Movie Session Not Found");
        if (createShoppingCartDto.SeatsIds.Count != createShoppingCartDto.TicketsCount)
        {
            return Result.Fail("Seats list number and Tickets count number do not match");
        }

        List<Seat> seats = new List<Seat>();

        foreach (var seatId in createShoppingCartDto.SeatsIds)
        {
            Seat seat = _unitOfWork.Seat.GetById(x => x.Id == seatId);
            if (seat == null) return Result.Fail($"Seat of id {seatId} not found");
            if (seat.MovieSessionId != createShoppingCartDto.MovieSessionId) return Result.Fail($"Seat of id {seatId} do not belong to this movie session");
            if (seat.IsAvailable == false) return Result.Fail($"Seat {seat.Name} is not available");
            seats.Add(seat);
        }

        //todo if shopping cart exist remove it than create new

        ShoppingCart shoppingCart = _mapper.Map<ShoppingCart>(createShoppingCartDto);

        shoppingCart.Seats = seats;
        shoppingCart.UserId = Convert.ToInt32(userId);
        User user = _unitOfWork.User.GetById(x => x.Id == shoppingCart.UserId);
        shoppingCart.User = user;
        shoppingCart.MovieSession = movieSession;
        shoppingCart.TotalPrice = shoppingCart.MovieSession.Price * shoppingCart.TicketsCount;

        _unitOfWork.ShoppingCart.Add(shoppingCart);
        _unitOfWork.Save();

        ReadShoppingCartDto readShoppingCartDto = _mapper.Map<ReadShoppingCartDto>(shoppingCart);
        return Result.Ok(readShoppingCartDto);
    }

    public Result DeleteShoppingCart(int id)
    {
        ShoppingCart shoppingCart = _unitOfWork.ShoppingCart.GetById(x => x.Id == id);
        if (shoppingCart == null) return Result.Fail("Shopping cart not found");
        _unitOfWork.ShoppingCart.Remove(shoppingCart);
        _unitOfWork.Save();
        return Result.Ok();
    }

    public ReadShoppingCartDto GetShoppingCartById(int id)
    {
        ShoppingCart shoppingCart = _unitOfWork.ShoppingCart.GetById(x => x.Id == id);
        if (shoppingCart != null)
        {
            ReadShoppingCartDto readShoppingCartDto = _mapper.Map<ReadShoppingCartDto>(shoppingCart);
            return readShoppingCartDto;
        }
        return null;
    }

    public Result Order(int id, StripeCard card)
    {
        ShoppingCart shoppingCart = _unitOfWork.ShoppingCart.GetById(x =>x.Id == id);
        if (shoppingCart == null) return Result.Fail("Shopping Cart Not Found");

        PaymentIntent paymentResult;
        try
        {
            //create payment method
            var optionsPaymentMethod = new PaymentMethodCreateOptions
            {
                Type = "card",
                Card = new PaymentMethodCardOptions
                {
                    Number = card.CardNumber,
                    ExpMonth = card.ExpirationMonth,
                    ExpYear = card.ExpirationYear,
                    Cvc = card.Cvc,
                },
            };
            var paymentMethodService = new PaymentMethodService();
            PaymentMethod paymentMethod = paymentMethodService.Create(optionsPaymentMethod);

            //create payment intent
            var options = new PaymentIntentCreateOptions
            {
                Amount = Convert.ToInt32(shoppingCart.TotalPrice * 100),
                Currency = "brl",
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
                PaymentMethod = paymentMethod.Id,
                Confirm = true
            };
            var service = new PaymentIntentService();

            //request payment
            paymentResult = service.Create(options);
        }
        catch(StripeException e)
        {
            if (e.StripeError.Type == "card_error")
            {
                 return Result.Fail($"A payment error occurred: {e.StripeError.Message}");
            }
            return Result.Fail($"Another problem occurred: {e.StripeError.Message}");
        }
        if (paymentResult.Status != "succeeded") return Result.Fail($"Error, your paymeent is {paymentResult.Status}");

        if (paymentResult.Status == "succeeded")
        {
            foreach(var seat in shoppingCart.Seats)
            {
                seat.IsAvailable = false;
                Ticket ticket = new Ticket();
                ticket.UserId = shoppingCart.UserId;
                ticket.User = shoppingCart.User;
                ticket.MovieSessionId = shoppingCart.MovieSessionId;
                ticket.MovieSession = shoppingCart.MovieSession;
                ticket.SeatId = seat.Id;
                ticket.Seat = seat;
                ticket.Date = shoppingCart.MovieSession.StartDateTime;
                ticket.PaymentIntentId = paymentResult.Id;

                _unitOfWork.Ticket.Add(ticket);
                _unitOfWork.Save();
            }

            _unitOfWork.ShoppingCart.Remove(shoppingCart);
            _unitOfWork.Save();
        }

        return Result.Ok();
    }

    public Result<ReadShoppingCartDto> PutShoppingCart(int id, UpdateShoppingCartDto updateShoppingCartDto)
    {
        ShoppingCart shoppingCart = _unitOfWork.ShoppingCart.GetById(x => x.Id == id);
        if (shoppingCart == null) return null;
        MovieSession movieSession = _unitOfWork.MovieSession.GetById(x => x.Id == updateShoppingCartDto.MovieSessionId);
        if (movieSession == null) return Result.Fail("Movie Session Not Found");
        if (updateShoppingCartDto.SeatsIds.Count != updateShoppingCartDto.TicketsCount)
        {
            return Result.Fail("Seats list number and Tickets count number do not match");
        }

        List<Seat> seats = new List<Seat>();

        foreach (var seatId in updateShoppingCartDto.SeatsIds)
        {
            Seat seat = _unitOfWork.Seat.GetById(x => x.Id == seatId);
            if (seat == null) return Result.Fail($"Seat of id {seatId} not found");
            if (seat.MovieSessionId != updateShoppingCartDto.MovieSessionId) return Result.Fail($"Seat of id {seatId} do not belong to this movie session");
            if (seat.IsAvailable == false) return Result.Fail($"Seat {seat.Name} is not available");
            seats.Add(seat);
        }

        shoppingCart.Seats.Clear();
        shoppingCart.Seats = seats;
        shoppingCart.MovieSessionId = updateShoppingCartDto.MovieSessionId;
        shoppingCart.TicketsCount = updateShoppingCartDto.TicketsCount;
        shoppingCart.MovieSession = movieSession;
        shoppingCart.TotalPrice = shoppingCart.MovieSession.Price * shoppingCart.TicketsCount;

        _unitOfWork.ShoppingCart.Update(shoppingCart);
        _unitOfWork.Save();

        ReadShoppingCartDto readShoppingCartDto = _mapper.Map<ReadShoppingCartDto>(shoppingCart);
        return Result.Ok(readShoppingCartDto);
    }
}
