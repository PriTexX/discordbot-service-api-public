using DiscordBotAPI.Models;
using DiscordBotAPI.services;
using Microsoft.AspNetCore.Mvc;

namespace DiscordBotAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly IActiveDirectoryService _activeDirectory;
    private readonly IStudentInfoService _studentService;

    public LoginController(IActiveDirectoryService adService, IStudentInfoService studentService)
    {
        _activeDirectory = adService;
        _studentService = studentService;
    }

    [HttpPost]
    public IActionResult Post(UserCredentials credentials)
    {
        var guid = _activeDirectory.LoginUser(credentials.Login, credentials.Password);
        if (guid == null)
        {
            return BadRequest(credentials);
        }

        var studentInfo = _studentService.GetStudentInfo(guid);
        return new OkObjectResult(studentInfo);
    }
}