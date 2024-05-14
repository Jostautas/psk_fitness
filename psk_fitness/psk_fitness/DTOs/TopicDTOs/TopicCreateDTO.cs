using psk_fitness.Utilities;

namespace psk_fitness.DTOs;

public class TopicDTO
{
    public int Id {get; set;}
    public string? Title {get; set;}
    public string? Description {get; set;}
    public CssColor? CssColor {get; set;}
}