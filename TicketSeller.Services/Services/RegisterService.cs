using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using TicketSeller.Models.Dtos.UserDto;
using TicketSeller.Models.Models;
using TicketSeller.Models.Requests;
using TicketSeller.Services.Services.IServices;

namespace TicketSeller.Services.Services;

public class RegisterService : IRegisterService
{
    private readonly IMapper _mapper;
    private readonly UserManager<IdentityUser<int>> _userManager;

    public RegisterService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    } 
    
    public Result RegisterUser(CreateUserDto createUserDto)
    {
        User user = _mapper.Map<User>(createUserDto);
        IdentityUser<int> identityUser = _mapper.Map<IdentityUser<int>>(user);
        Task<IdentityResult> identityResult = _userManager.CreateAsync(identityUser, createUserDto.Password);
        if (identityResult.Result.Succeeded)
        {
            Task<string> code = _userManager.GenerateEmailConfirmationTokenAsync(identityUser);
            return Result.Ok().WithSuccess(code.Result);
        }
        return Result.Fail("Fail to register User");
    }

    public Result ConfirmUserAccount(ConfirmUserAccountRequest confirmUserAccountRequest)
    {
        IdentityUser<int>? IdentityUser = _userManager
            .Users
            .FirstOrDefault(user => 
            user.Id == confirmUserAccountRequest.UserId);
        IdentityResult identityResult = _userManager
            .ConfirmEmailAsync(IdentityUser, confirmUserAccountRequest.ConfirmUserAccountToken).Result;
        if (identityResult.Succeeded) return Result.Ok();
        return Result.Fail("Fail to confirm Acconunt");

    }
}
