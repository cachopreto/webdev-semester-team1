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
    private readonly ILoginService _loginService;
    private readonly ILogger<AdminController> _logger;

    public AdminController(ILoginService loginService, ILogger<AdminController> logger)
    {
        _loginService = loginService;
        _logger = logger;
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
            _logger.LogError(ex, "Login error occurred: {Message}, Stack trace: {StackTrace}", ex.Message, ex.StackTrace);
            return StatusCode(500, new { error = $"Login error: {ex.Message}" });
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
