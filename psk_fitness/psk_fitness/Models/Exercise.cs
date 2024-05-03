namespace psk_fitness.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public required int WorkoutId { get; set; }
        public required string Title { get; set; }
        public DateOnly? Duration { get; set; }
        public int? Sets { get; set; }
        public int? Reps { get; set; }
        public string Description { get; set; } = "";
        public string Notes { get; set; } = "";
        public string FriendsNotes { get; set; } = "";
        public string Steps { get; set; } = "";
    }
}
