using Auction.API.Repositories;

namespace Auction.API.UseCases.Auctions.GetCurrent;

public static class GetCurrentUseCases
{
    public static Entities.Auction Execute()
    {
        var repository = new AuctionDbContext();
        return repository.Auctions.First();
    }
}