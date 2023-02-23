using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class CookieTest2Controller : Controller
{
    [HttpGet]
    public string Get()
    {
        // Get the cookie
        var cookie = Request.Cookies["joySecret"];
        
        // Return the cookie
        return cookie ?? "Could not find the secret to joy :-(";
    }
}