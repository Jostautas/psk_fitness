using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace psk_fitness.Data
{
    public class Workout
    {
        [Key] public int Id { get; set; }
        [ForeignKey("Topic")]
        public required int TopicId { get; set; }
        public required string Title { get; set; }
        public required DateOnly Date {  get; set; }
        public TimeSpan? Duration { get; set; }
        public string Description { get; set; } = "";
        public string Notes { get; set; } = "";
        public string FriendsNotes { get; set; } = "";
        public bool Finished { get; set; } = false;

        public required virtual Topic Topic { get; set; }
        public virtual ICollection<Exercise>? Exercises { get; set; }


    }
}
