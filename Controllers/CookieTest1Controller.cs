using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class CookieTest1Controller : Controller
{
    [HttpGet]
    public string Get()
    {
        // Create our cookie options
        var options = new CookieOptions
        {
            // Set the expiration to 5 minutes from now
            Expires = DateTime.Now.AddMinutes(5)
        };
        
        const string value = "The key to joy is happiness in the household";

        // Set the cookie
        Response.Cookies.Append("joySecret", value, options);
        
        // Return the key
        return value;
    }
}