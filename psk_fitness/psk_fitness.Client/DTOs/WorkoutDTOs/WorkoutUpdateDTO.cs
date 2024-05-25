using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace psk_fitness.Client.DTOs.WorkoutDTOs
{
    public class WorkoutUpdateDTO
    {
        public int Id { get; set; }
        public required int TopicId { get; set; }
        public required string Title { get; set; }
        public required DateOnly Date { get; set; }
        public TimeSpan? Duration { get; set; }
        public string Description { get; set; } = "";
        public string Notes { get; set; } = "";
        public string FriendsNotes { get; set; } = "";
        public bool Finished { get; set; } = false;
        public required virtual Topic Topic { get; set; }
        public virtual ICollection<Exercise>? Exercises { get; set; }
    }
}
