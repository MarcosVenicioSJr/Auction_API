using Auction.API.Comunication.Requests;
using Auction.API.Filters;
using Auction.API.UseCases.Offers.CreateOffer;
using Microsoft.AspNetCore.Mvc;

namespace Auction.API.Controllers;

[Route("[controller]")]
[ApiController]
public class OfferController : BaseController
{
    [HttpPost]
    [Route("{itemId}")]
    [ServiceFilter(typeof(AuthenticationUserAttribute))]
    public async Task<IActionResult> Create([FromRoute] int itemId, [FromBody] RequestCreateOfferJson request,
        [FromServices] CreateOfferUseCase userCase)
    {
        int id = await userCase.Execute(itemId, request);
        return Created(string.Empty, "Oferta criada com sucesso, ID: " + id);
    }
}