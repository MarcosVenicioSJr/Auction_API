using Auction.API.Comunication.Requests;
using Auction.API.Entities;
using Auction.API.Repositories;
using Auction.API.Services;

namespace Auction.API.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{
    private readonly LoggedUser _loggedUser;

    public CreateOfferUseCase(LoggedUser loggedUser)
    {
        _loggedUser = loggedUser;
    }
    
    public async Task<int> Execute(int itemId, RequestCreateOfferJson request)
    {
        var repository = new AuctionDbContext();
        var user = _loggedUser.Logged();
        
        Offer offer = new Offer()
        {
            Price = request.price,
            CreatedOn = DateTime.UtcNow,
            ItemId = itemId,
            UserId = user.Id
        };
        
        await repository.Offers.AddAsync(offer);
        await repository.SaveChangesAsync();
        return offer.Id;
    }
}