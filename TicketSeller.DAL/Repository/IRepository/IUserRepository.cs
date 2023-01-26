using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;
using TicketSeller.Models.Models;

namespace TicketSeller.DAL.Repository.IRepository;

public interface IUserRepository : IRepository<User>
{
    Task<IdentityResult> AddToRoleAsync(User user, string role);
    Task<IdentityResult> ConfirmEmailAsync(User? user, string confirmUserAccountToken);
    Task<IdentityResult> CreateAsync(User user, string password);
    Task<string> GenerateEmailConfirmationTokenAsync(User user);
    Task<string> GeneratePasswordResetTokenAsync(User user);
    User? GetByUsername(Func<User, bool> func);
    User? GetIdentityUserByEmail(string email);
    Task<IList<string>> GetRolesAsync(User? user);
    Task<SignInResult> PasswordSignInAsync(string username, string password, bool isPersistent, bool lockoutOnFailure);
    Task<IdentityResult> ResetPasswordAsync(User? user, string token, string password);
    Task SignOutAsync();
}
