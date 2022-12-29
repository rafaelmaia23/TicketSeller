using FluentResults;
using TicketSeller.Models.Dtos.UserDto;
using TicketSeller.Models.Requests;

namespace TicketSeller.Services.Services.IServices;

public interface IRegisterService
{   
    Result RegisterUser(CreateUserDto createUserDto);
    Result ConfirmUserAccount(ConfirmUserAccountRequest confirmUserAccountRequest);
}
