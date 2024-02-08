using Auction.API.Contracts;
using Auction.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace Auction.API.Filters;

public class AuthenticationUserAttribute
{
    private IUserRepository _userRepository;
    
    public AuthenticationUserAttribute(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async void OnAuthorization(AuthorizationFilterContext context)
    {
        string token = TokenOnRequest(context.HttpContext);

        string email = FromBase64(token);
        bool exists = await _userRepository.ExistsUserWithEmail(email);

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