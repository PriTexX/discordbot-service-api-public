using DiscordBotAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiscordBotAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly DiscordBotApiContext _database;

    public UserController(DiscordBotApiContext context)
    {
        _database = context;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get(string discordUserId)
    {
        var discordUser = await _database.DiscordUsers.FirstOrDefaultAsync(u => u.DiscordUserId == discordUserId);
        if (discordUser?.DiscordUserId == string.Empty)
        {
            return NotFound();
        }

        return new ObjectResult(discordUser);
    }

    [HttpPost]
    public async Task<IActionResult> Post(DiscordUser discordUser)
    {
        if (await _database.DiscordUsers.AnyAsync(d => d.DiscordUserId == discordUser.DiscordUserId))
        {
            return StatusCode(422, "User with this id already exists");
        }
        await _database.DiscordUsers.AddAsync(discordUser);
        await _database.SaveChangesAsync();

        return Ok();
    }
}