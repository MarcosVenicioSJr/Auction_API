using Auction.API.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Auction.API.Repositories.DataAccess;

public class AuctionRepository : IAuctionRepository
{
    private readonly AuctionDbContext _auctionDbContext;

    public AuctionRepository(AuctionDbContext auctionDbContext)
    {
        _auctionDbContext = auctionDbContext;
    }

    public async Task<Entities.Auction?> GetCurrent()
    {
        return await _auctionDbContext
            .Auctions
            .Include(auction => auction.Items)
            .FirstOrDefaultAsync(auction => DateTime.UtcNow >= auction.Starts
                                            && DateTime.UtcNow <= auction.Ends);
    }
}