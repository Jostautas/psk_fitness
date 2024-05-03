using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace psk_fitness.Data
{
    public class Exercise
    {
        [Key] public int Id { get; set; }
        [ForeignKey("Workout")]
        public required int WorkoutId { get; set; }
        public required string Title { get; set; }
        public DateOnly? Duration { get; set; }
        public int? Sets { get; set; }
        public int? Reps { get; set; }
        public string Description { get; set; } = "";
        public string Notes { get; set; } = "";
        public string FriendsNotes { get; set; } = "";
        public string Steps { get; set; } = "";

        public virtual Workout? Workout { get; set; }
    }
}
