using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Web;
using TicketSeller.Models.Dtos.UserDto;
using TicketSeller.Models.Models;
using TicketSeller.Models.Requests;
using TicketSeller.Services.Services.IServices;

namespace TicketSeller.Services.Services;

public class RegisterService : IRegisterService
{
    private readonly IMapper _mapper;
    private readonly UserManager<IdentityUser<int>> _userManager;
    private readonly IEmailService _emailService;
    private readonly RoleManager<IdentityRole<int>> _roleManager;

    public RegisterService(IMapper mapper, UserManager<IdentityUser<int>> userManager, IEmailService emailService, RoleManager<IdentityRole<int>> roleManager)
    {
        _mapper = mapper;
        _userManager = userManager;
        _emailService = emailService;
        _roleManager = roleManager;
    }

    public Result RegisterUser(CreateUserDto createUserDto)
    {
        User user = _mapper.Map<User>(createUserDto);
        IdentityUser<int> identityUser = _mapper.Map<IdentityUser<int>>(user);
        Task<IdentityResult> identityResult = _userManager
            .CreateAsync(identityUser, createUserDto.Password);
        identityResult.Wait();
        var roleResult = _userManager.AddToRoleAsync(identityUser, "client");
        roleResult.Wait();
        if (identityResult.Result.Succeeded)
        {
            Task<string> code = _userManager.GenerateEmailConfirmationTokenAsync(identityUser);
            string encodedCode = HttpUtility.UrlEncode(code.Result);
            //_emailService.SendConfirmationEmail(new[] { identityUser.Email }, "Account Confirmation Link", 
            //    identityUser.Id, encodedCode);

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
