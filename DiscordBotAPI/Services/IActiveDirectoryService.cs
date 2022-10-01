using System.DirectoryServices;

namespace DiscordBotAPI.services;

public interface IActiveDirectoryService
{
    public string? LoginUser(string login, string password);
}