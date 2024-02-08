using Auction.API.Entities;

namespace Auction.API.Contracts;

public interface IUserRepository
{
    Task<bool> ExistsUserWithEmail(string email);
    Task<User?> GetByEmail(string email);
}