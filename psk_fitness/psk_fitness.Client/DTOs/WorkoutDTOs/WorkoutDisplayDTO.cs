
namespace psk_fitness.Client.DTOs.WorkoutDTOs;
public class WorkoutDisplayDTO
{ 
    public int TopicId { get; set; }
    public string Title { get; set; } = "No title";
    public DateOnly Date { get; set; }
    public TimeSpan? Duration { get; set; }
    public string Description { get; set; } = "";
    public string Notes { get; set; } = "";
    public string FriendsNotes { get; set; } = "";
    public bool Finished { get; set; } = false;
}
