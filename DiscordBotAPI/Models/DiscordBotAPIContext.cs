using Microsoft.EntityFrameworkCore;

namespace DiscordBotAPI.Models;

public class DiscordBotApiContext : DbContext 
{
    public DiscordBotApiContext()
    {
        //Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=myhost.ru;Port=5112;Database=fitdiscordapi;User ID=postgres;Password=12345654321;");
    }

    public DbSet<DiscordUser> DiscordUsers { get; set; }
}