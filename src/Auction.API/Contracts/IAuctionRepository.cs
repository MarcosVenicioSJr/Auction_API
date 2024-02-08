namespace Auction.API.Contracts;

public interface IAuctionRepository
{
    Task<Entities.Auction?> GetCurrent();
}