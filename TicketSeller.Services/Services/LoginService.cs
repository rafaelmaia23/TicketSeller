using FluentResults;
using Microsoft.AspNetCore.Identity;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Models;
using TicketSeller.Models.Requests;
using TicketSeller.Models.Tokens;
using TicketSeller.Services.Services.IServices;

namespace TicketSeller.Services.Services;

public class LoginService : ILoginService
{
    private readonly ILoginTokenService _loginTokenService;
    private readonly IUnitOfWork _unitOfWork;

    public LoginService(ILoginTokenService loginTokenService, IUnitOfWork unitOfWork)
    {
        _loginTokenService = loginTokenService;
        _unitOfWork = unitOfWork;
    }

    public Result LoginUser(LoginRequest loginRequest)
    {
        Task<SignInResult> identityResult = _unitOfWork.User
            .PasswordSignInAsync(loginRequest.Username, loginRequest.Password, false, false);
        
        if (identityResult.Result.Succeeded) 
        {
            User? user = _unitOfWork.User
                .GetByUsername(x => x.NormalizedUserName == loginRequest.Username.ToUpper());            

            LoginToken loginToken = _loginTokenService
                .CreateLoginToken(user!, _unitOfWork.User.GetRolesAsync(user).Result.FirstOrDefault());
            return Result.Ok().WithSuccess(loginToken.Value);
        }
        return Result.Fail("Login Fail");
    }

    public Result GeneratePasswordReset(GeneratePasswordResetRequest generatePasswordResetRequest)
    {
        User? user = _unitOfWork.User.GetIdentityUserByEmail(generatePasswordResetRequest.Email);
        if (user != null)
        {
            string resetToken = _unitOfWork.User.GeneratePasswordResetTokenAsync(user).Result;                
            return Result.Ok().WithSuccess(resetToken);
        }
        return Result.Fail("Fail to request password reset");
    }

    public Result ResetPassword(ResetPasswordRequest resetPasswordRequest)
    {
        User? user = _unitOfWork.User.GetIdentityUserByEmail(resetPasswordRequest.Email);
        IdentityResult identityResult = _unitOfWork.User
            .ResetPasswordAsync(user, resetPasswordRequest.Token, resetPasswordRequest.Password).Result;
        if (identityResult.Succeeded) return Result.Ok().WithSuccess("Success in Reset Password");
        return Result.Fail("Fail to reset password");
    }    
}
