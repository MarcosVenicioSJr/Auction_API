using Auction.API.Comunication.Requests;
using Auction.API.Contracts;
using Auction.API.Entities;
using Auction.API.Repositories;
using Auction.API.Services;

namespace Auction.API.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{
    private readonly LoggedUser _loggedUser;
    private readonly IOfferRepository _repository;

    public CreateOfferUseCase(LoggedUser loggedUser, IOfferRepository repository)
    {
        _loggedUser = loggedUser;
        _repository = repository;
    }
    
    public async Task<int> Execute(int itemId, RequestCreateOfferJson request)
    {
        var user = _loggedUser.Logged();
        
        Offer offer = new Offer()
        {
            Price = request.price,
            CreatedOn = DateTime.UtcNow,
            ItemId = itemId,
            UserId = user.Id
        };
        
        _repository.Add(offer);
        return offer.Id;
    }
}