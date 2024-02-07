using Auction.API.UseCases.Auctions.GetCurrent;
using Microsoft.AspNetCore.Mvc;

namespace Auction.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuctionController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(Entities.Auction), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetCurrentAuction()
        {
            Entities.Auction auction = await GetCurrentUseCases.Execute();

            if (auction is null)
                return NoContent();
                
            return Ok(auction);
        }
    }
}
