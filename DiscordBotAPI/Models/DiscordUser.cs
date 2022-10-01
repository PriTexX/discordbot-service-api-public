using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscordBotAPI.Models;

[Table("detail")]
public class DiscordUser
{
    [Key]
    [Column("discorduserid")]
    [Required]
    public string DiscordUserId { get; set; }
    
    [Required]
    [Column("onecguid")]
    public string OneCGuid { get; set; }
    
}