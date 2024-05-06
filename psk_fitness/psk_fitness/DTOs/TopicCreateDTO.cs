using System.Text.Json.Serialization;
using psk_fitness.Utilities;

namespace psk_fitness.DTOs;

public class TopicCreateDTO
{
    public string? Title {get; set;}
    public string? Description {get; set;}
    public CssColor? CssColor {get; set;}
}