using Auction.API.Contracts;
using Auction.API.Entities;
using Auction.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Auction.API.Services;

public class LoggedUser
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IUserRepository _userRepository;
    
    public LoggedUser(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
    {
        _contextAccessor = httpContextAccessor;
        _userRepository = userRepository;
    }
    
    public async Task<User?> Logged()
    {
        string email = TokenOnRequest(_contextAccessor.HttpContext);

        return await _userRepository.GetByEmail(email);
    }
    
    private string TokenOnRequest(HttpContext context)
    {
        string tokenRequest = context.Request.Headers.Authorization.ToString();
        string tokenBase64 = tokenRequest["Bearer ".Length..];
        return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(tokenBase64));
    }
}