using Auction.API.Entities;
using Auction.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Auction.API.Services;

public class LoggedUser
{
    private readonly IHttpContextAccessor _contextAccessor;
    
    public LoggedUser(IHttpContextAccessor httpContextAccessor)
    {
        _contextAccessor = httpContextAccessor;
    }
    
    public async Task<User> Logged()
    {
        var repository = new AuctionDbContext();

        var email = TokenOnRequest(_contextAccessor.HttpContext);
        
        return await repository.Users.FirstOrDefaultAsync(user => user.Email.Equals(email));
    }
    
    private string TokenOnRequest(HttpContext context)
    {
        string tokenRequest = context.Request.Headers.Authorization.ToString();
        var tokenBase64 = tokenRequest["Bearer ".Length..];
        return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(tokenBase64));
    }
}