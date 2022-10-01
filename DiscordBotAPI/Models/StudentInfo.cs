using System.ComponentModel.DataAnnotations;

namespace DiscordBotAPI.Models;

public class StudentInfo
{
    [Required]
    public string Department { get; set; }
    
    [Required]
    public string Group { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Surname { get; set; }

    [Required]
    public string OneCGuid { get; set; }
}