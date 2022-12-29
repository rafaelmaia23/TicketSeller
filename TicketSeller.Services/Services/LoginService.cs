using FluentResults;
using Microsoft.AspNetCore.Identity;
using TicketSeller.Models.Requests;
using TicketSeller.Models.Tokens;
using TicketSeller.Services.Services.IServices;

namespace TicketSeller.Services.Services;

public class LoginService : ILoginService
{
    private readonly SignInManager<IdentityUser<int>> _signInManager;
    private readonly ILoginTokenService _loginTokenService;

    public LoginService(SignInManager<IdentityUser<int>> signInManager, ILoginTokenService loginTokenService)
    {
        _signInManager = signInManager;
        _loginTokenService = loginTokenService;
    }

    public Result LoginUser(LoginRequest loginRequest)
    {
        Task<SignInResult> identityResult = _signInManager
            .PasswordSignInAsync(loginRequest.Username, loginRequest.Password, false, false);

        if (identityResult.Result.Succeeded) 
        {
            IdentityUser<int>? identityUser = _signInManager
                .UserManager
                .Users
                .FirstOrDefault(user =>
                user.NormalizedUserName == loginRequest.Username.ToUpper());

            LoginToken loginToken = _loginTokenService.CreateLoginToken(identityUser!);
            return Result.Ok().WithSuccess(loginToken.Value);
        }

        return Result.Fail("Login Fail");
    }
}
