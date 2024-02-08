using Auction.API.Contracts;
using Auction.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auction.API.Repositories.DataAccess;

public class UserRepository : IUserRepository
{
    private readonly AuctionDbContext _auctionDbContext;

    public UserRepository(AuctionDbContext auctionDbContext)
    {
        _auctionDbContext = auctionDbContext;
    }

    public async Task<bool> ExistsUserWithEmail(string email)
    {
       return await _auctionDbContext.Users.AnyAsync(user => user.Email.Equals(email));
    }

    public async Task<User?> GetByEmail(string email)
    {
        return await _auctionDbContext.Users.FirstOrDefaultAsync(user => user.Email.Equals(email));
    }
}