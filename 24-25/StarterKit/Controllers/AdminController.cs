using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using StarterKit.Models;
using StarterKit.Services;

namespace StarterKit.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly LoginService _loginService;

    public AdminController(LoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        if (!ModelState.IsValid) 
            return BadRequest(new { error = "Invalid username or password format." });
        try
        {
            var result = await _loginService.LoginAsync(loginRequest.Username, loginRequest.Password);
            if (result == "Login successful")
                return Ok(new { message = result });
            
            return BadRequest(new { error = result });
        }
        catch (Exception ex)
        {
            // Log exception (optional)
            Debug.WriteLine(ex.Message);
            return StatusCode(500, new { error = "An unexpected error occurred. Please try again later." });
        }
    }
    
    [HttpGet("isLoggedIn")]
    public IActionResult IsLoggedIn()
    {
        var isLoggedIn = _loginService.IsLoggedIn(out var username);
        return Ok(new { isLoggedIn, username });
    }
}

public class LoginRequest
{
    [Required]
    public string Username { get; set; } = string.Empty;
    
    [Required]
    public string Password { get; set; } = string.Empty;
}
