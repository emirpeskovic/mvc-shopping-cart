using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class MilkshakeController : Controller
{
    [HttpGet("{favorite}")]
    public string Get(string favorite)
    {
        // Create our cookie options
        var options = new CookieOptions
        {
            // Set the expiration to 5 minutes from now
            Expires = DateTime.Now.AddMinutes(5)
        };

        // Set the cookie
        Response.Cookies.Append("favoriteMilkshake", favorite, options);
        
        // Return the favorite milkshake
        return favorite;
    }
    
    [HttpGet]
    public string Get()
    {
        // Return the favorite milkshake, or some text if it doesn't exist
        return Request.Cookies["favoriteMilkshake"] ?? "Unknown favorite milkshake :-(";
    }
    
    [HttpGet("clear")]
    public string Clear()
    {
        // Clear the cookie
        Response.Cookies.Delete("favoriteMilkshake");
        
        // Return a message
        return "Favorite milkshake cleared";
    }
}