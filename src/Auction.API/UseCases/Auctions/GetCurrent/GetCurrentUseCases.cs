using Auction.API.Contracts;
using Auction.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Auction.API.UseCases.Auctions.GetCurrent;

public class GetCurrentUseCases
{
    private readonly IAuctionRepository _repository;

    public GetCurrentUseCases(IAuctionRepository repository)
    {
        _repository = repository;
    }

    public async Task<Entities.Auction?> Execute()
    {
        return await _repository.GetCurrent();
    }
}