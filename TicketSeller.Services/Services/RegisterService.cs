using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Web;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Dtos.UserDto;
using TicketSeller.Models.Models;
using TicketSeller.Models.Requests;
using TicketSeller.Services.Services.IServices;

namespace TicketSeller.Services.Services;

public class RegisterService : IRegisterService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;    
    private readonly IEmailService _emailService;

    public RegisterService(IMapper mapper, IEmailService emailService, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _emailService = emailService;
        _unitOfWork = unitOfWork;
    }

    public Result RegisterUser(CreateUserDto createUserDto)
    {
        User user = _mapper.Map<User>(createUserDto);
        Task<IdentityResult> identityResult = _unitOfWork.User.CreateAsync(user, createUserDto.Password);        
        identityResult.Wait();
        Task<IdentityResult> roleResult = _unitOfWork.User.AddToRoleAsync(user, "client");            
        roleResult.Wait();
        if (identityResult.Result.Succeeded)
        {
            Task<string> code = _unitOfWork.User.GenerateEmailConfirmationTokenAsync(user);                
            string encodedCode = HttpUtility.UrlEncode(code.Result);
            //_emailService.SendConfirmationEmail(new[] { identityUser.Email }, "Account Confirmation Link", 
            //    identityUser.Id, encodedCode);
            return Result.Ok().WithSuccess(code.Result);
        }
        return Result.Fail("Fail to register User");
    }

    public Result ConfirmUserAccount(ConfirmUserAccountRequest confirmUserAccountRequest)
    {
        User? user = _unitOfWork.User.GetById(x =>
            x.Id == confirmUserAccountRequest.UserId);
        IdentityResult identityResult = _unitOfWork.User
            .ConfirmEmailAsync(user, confirmUserAccountRequest.ConfirmUserAccountToken).Result;
        if (identityResult.Succeeded) return Result.Ok();
        return Result.Fail("Fail to confirm Acconunt");
    }
}
