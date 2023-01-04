using FluentResults;
using Microsoft.AspNetCore.Identity;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Requests;
using TicketSeller.Models.Tokens;
using TicketSeller.Services.Services.IServices;

namespace TicketSeller.Services.Services;

public class LoginService : ILoginService
{
    private readonly SignInManager<IdentityUser<int>> _signInManager;
    private readonly ILoginTokenService _loginTokenService;
    private readonly IUnitOfWork _unitOfWork;

    public LoginService(SignInManager<IdentityUser<int>> signInManager, ILoginTokenService loginTokenService, IUnitOfWork unitOfWork)
    {
        _signInManager = signInManager;
        _loginTokenService = loginTokenService;
        _unitOfWork = unitOfWork;
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

            LoginToken loginToken = _loginTokenService
                .CreateLoginToken(identityUser!,
                _signInManager.UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault());
            return Result.Ok().WithSuccess(loginToken.Value);
        }

        return Result.Fail("Login Fail");
    }

    public Result GeneratePasswordReset(GeneratePasswordResetRequest generatePasswordResetRequest)
    {
        IdentityUser<int>? identityUser = _unitOfWork.User.GetIdentityUserByEmail(generatePasswordResetRequest.Email);
        if (identityUser != null)
        {
            string resetToken = _signInManager
                .UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;
            return Result.Ok().WithSuccess(resetToken);
        }
        return Result.Fail("Fail to request password reset");
    }

    public Result ResetPassword(ResetPasswordRequest resetPasswordRequest)
    {
        IdentityUser<int>? identityUser = _unitOfWork.User.GetIdentityUserByEmail(resetPasswordRequest.Email);
        IdentityResult identityResult = _signInManager
            .UserManager
            .ResetPasswordAsync(identityUser, resetPasswordRequest.Token, resetPasswordRequest.Password)
            .Result;
        if (identityResult.Succeeded) return Result.Ok().WithSuccess("Success in Reset Password");
        return Result.Fail("Fail to reset password");
    }    
}
