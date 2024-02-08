using Auction.API.Contracts;
using Auction.API.Entities;

namespace Auction.API.Repositories.DataAccess;

public class OfferRepository : IOfferRepository
{
    private readonly AuctionDbContext _auctionDbContext;

    public OfferRepository(AuctionDbContext auctionDbContext)
    {
        _auctionDbContext = auctionDbContext;
    }
    
    public async void Add(Offer offer)
    {
        await _auctionDbContext.Offers.AddAsync(offer);
        await _auctionDbContext.SaveChangesAsync();
    }
}