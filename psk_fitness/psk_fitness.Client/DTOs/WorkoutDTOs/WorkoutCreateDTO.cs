

namespace psk_fitness.Client.DTOs.WorkoutDTOs
{
    public class WorkoutCreateDTO
    {
        public string Title { get; set; } = "No title";
        public DateOnly Date { get; set; }
        public TimeSpan? Duration { get; set; }
        public string Description { get; set; } = "";
        public string Notes { get; set; } = "";
        public string FriendsNotes { get; set; } = "";
        public bool Finished { get; set; } = false;

        public int TopicId { get; set; }
    }
}
