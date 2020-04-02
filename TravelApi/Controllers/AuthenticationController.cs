using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TravelApi.Models;
using TravelApi.Entities;
using TravelApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticateService _authService;
    public AuthenticationController(IAuthenticateService authService)
    {
        _authService = authService;
    }

    [AllowAnonymous]
    [HttpPost, Route("request")]
    public IActionResult RequestToken([FromBody] TokenRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        string token;
        if (_authService.IsAuthenticated(request, out token))
        {
            return Ok(token); 
        }

        return BadRequest("Invalid Request");

    }

    [AllowAnonymous]  
    [HttpPost, Route("token")]  
    public IActionResult Authenticate([FromBody] TokenRequest userParam) {  
        var user = _authService.UserIsValid(userParam.Username, userParam.Password);  

        if (user == false) {  
            return BadRequest(new {  
                message = "UserName or Password is invalid"  
            });  
        }  
        return Ok(User.Identity);  
    }  

}