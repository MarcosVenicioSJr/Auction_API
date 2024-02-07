using Auction.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace Auction.API.Filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    public async void OnAuthorization(AuthorizationFilterContext context)
    {
        string token = TokenOnRequest(context.HttpContext);

        var repository = new AuctionDbContext();

        string email = FromBase64(token);
        bool exists = await repository.Users.AnyAsync(user => user.Email.Equals(email));

        if (!exists)
            context.Result = new UnauthorizedObjectResult("Token not found");
    }

    private string TokenOnRequest(HttpContext context)
    {
        string token = context.Request.Headers.Authorization.ToString();
        return token["Bearer ".Length..];
    }

    private string FromBase64(string base64)
    {
        return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(base64));
    }
}