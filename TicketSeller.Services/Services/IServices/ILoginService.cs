using FluentResults;
using TicketSeller.Models.Requests;

namespace TicketSeller.Services.Services.IServices;

public interface ILoginService
{
    Result LoginUser(LoginRequest loginRequest);
    Result GeneratePasswordReset(GeneratePasswordResetRequest generatePasswordResetRequest);
    Result ResetPassword(ResetPasswordRequest resetPasswordRequest);
}
