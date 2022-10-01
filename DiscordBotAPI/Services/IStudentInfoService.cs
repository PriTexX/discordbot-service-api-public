using DirectoryManager;
using DiscordBotAPI.Models;

namespace DiscordBotAPI.services;

public interface IStudentInfoService : IDisposable, IConnectable
{
    public StudentInfo GetStudentInfo(string guid);
}