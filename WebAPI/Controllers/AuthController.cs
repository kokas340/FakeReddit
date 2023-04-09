using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.LogicInterfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shared.Dtos;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration config;
    private readonly IUserLogic userLogic;

    public AuthController(IConfiguration config, IUserLogic userLogic)
    {
        this.config = config;
        this.userLogic = userLogic;
    }

    [HttpPost, Route("register")]
    public async Task<ActionResult<User>> Register([FromBody] UserLoginDto user)
    {
        User u = await userLogic.CreateAsync(user);
        return Created($"/users/{u.Id}", u);
    }

    [HttpPost, Route("login")]
    public async Task<ActionResult> Login([FromBody] UserLoginDto userLoginDto)
    {
        try
        {
            User user = await userLogic.GetAsync(userLoginDto);
            Console.WriteLine("0");
            string token = GenerateJwt(user);
            
            return Ok(token);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    private string GenerateJwt(User user)
    {
        List<Claim> claims = GenerateClaims(user);
        Console.WriteLine("1");
        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
        Console.WriteLine("2");
        SigningCredentials signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
        Console.WriteLine("3");
        JwtHeader header = new JwtHeader(signIn);
        Console.WriteLine("4");
        JwtPayload payload = new JwtPayload(
            config["Jwt:Issuer"],
            config["Jwt:Audience"],
            claims, 
            null,
            DateTime.UtcNow.AddMinutes(60));
        Console.WriteLine("5");
        JwtSecurityToken token = new JwtSecurityToken(header, payload);
        Console.WriteLine("6");
        string serializedToken = new JwtSecurityTokenHandler().WriteToken(token);
        Console.WriteLine("7");
        return serializedToken;
    }

    private List<Claim> GenerateClaims(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, config["Jwt:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
        };
   
        return claims.ToList();
    }
}