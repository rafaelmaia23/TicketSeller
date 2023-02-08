using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;
using TicketSeller.DAL.Data;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Models;

namespace TicketSeller.DAL.Repository;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly AppDbContext _db;
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    public UserRepository(AppDbContext db, SignInManager<User> signInManager, UserManager<User> userManager) : base(db)
    {
        _db = db;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public Task<IdentityResult> AddToRoleAsync(User user, string role)
    {
        return _userManager
            .AddToRoleAsync(user, role);
    }

    public Task<IdentityResult> ConfirmEmailAsync(User? user, string confirmUserAccountToken)
    {
        return _userManager
            .ConfirmEmailAsync(user, confirmUserAccountToken);
    }

    public Task<IdentityResult> CreateAsync(User user, string password)
    {
        return _userManager
            .CreateAsync(user, password);
    }

    public Task<string> GenerateEmailConfirmationTokenAsync(User user)
    {
        return _userManager
            .GenerateEmailConfirmationTokenAsync(user);
    }

    public Task<string> GeneratePasswordResetTokenAsync(User user)
    {
        return _signInManager
            .UserManager
            .GeneratePasswordResetTokenAsync(user);
    }

    public override User? GetById(Expression<Func<User, bool>> expression)
    {
        return _userManager
            .Users
            .FirstOrDefault(expression);
    }

    public User? GetByUsername(Expression<Func<User, bool>> expression)
    {
        return _signInManager
                .UserManager
                .Users
                .FirstOrDefault(expression);
    }

    //public User? GetByUsername(Func<User, bool> func)
    //{
    //    throw new NotImplementedException();
    //}

    public User? GetIdentityUserByEmail(string email)
    {
        return _signInManager
            .UserManager
            .Users
            .FirstOrDefault(user =>
            user.NormalizedEmail == email.ToUpper());
    }

    public Task<IList<string>> GetRolesAsync(User? user)
    {
        return _signInManager
            .UserManager
            .GetRolesAsync(user);
    }

    public Task<SignInResult> PasswordSignInAsync(string username, string password, bool isPersistent, bool lockoutOnFailure)
    {
        return _signInManager
            .PasswordSignInAsync(username, password, false, false);
    }

    public Task<IdentityResult> ResetPasswordAsync(User? user, string token, string password)
    {
        return _signInManager
            .UserManager
            .ResetPasswordAsync(user!, token, password);
    }

    public Task SignOutAsync()
    {
        return _signInManager.SignOutAsync();
    }
}
