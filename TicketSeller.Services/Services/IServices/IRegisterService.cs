using FluentResults;
using TicketSeller.Models.Dtos.UserDto;

namespace TicketSeller.Services.Services.IServices;

public interface IRegisterService
{
    Result RegisterUser(CreateUserDto createUserDto);
}
