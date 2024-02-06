using Auction.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Auction.API.UseCases.Auctions.GetCurrent;

public static class GetCurrentUseCases
{
    public async static Task<Entities.Auction?> Execute()
    {
        var repository = new AuctionDbContext();
        return await repository
            .Auctions
            .Include(auction => auction.Items)
            .FirstOrDefaultAsync(auction => DateTime.UtcNow >= auction.Starts
                                       && DateTime.UtcNow <= auction.Ends);
    }
}