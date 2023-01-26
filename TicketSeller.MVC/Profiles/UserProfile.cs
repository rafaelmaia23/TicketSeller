using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TicketSeller.Models.Dtos.UserDto;
using TicketSeller.Models.Models;

namespace TicketSeller.API.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
    }
}