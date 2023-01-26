using FluentResults;
using Microsoft.AspNetCore.Identity;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Services.Services.IServices;

namespace TicketSeller.Services.Services;

public class LogoutService : ILogoutService
{
    private readonly IUnitOfWork _unitOfWork;

    public LogoutService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Result LogoutUser()
    {
        Task identityResult = _unitOfWork.User.SignOutAsync();            
        if (identityResult.IsCompletedSuccessfully) return Result.Ok();
        return Result.Fail("Logout Fail");
    }
}
