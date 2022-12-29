using FluentResults;
using Microsoft.AspNetCore.Identity;
using TicketSeller.Services.Services.IServices;

namespace TicketSeller.Services.Services;

public class LogoutService : ILogoutService
{
    private SignInManager<IdentityUser<int>> _signInManager;
    public LogoutService(SignInManager<IdentityUser<int>> signInManager)
    {
        _signInManager = signInManager;
    }

    public Result LogoutUser()
    {
        Task identityResult = _signInManager.SignOutAsync();
        if (identityResult.IsCompletedSuccessfully) return Result.Ok();
        return Result.Fail("Logout Fail");
    }
}
