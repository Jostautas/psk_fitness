namespace psk_fitness.DTOs
{
    public class ExerciseDisplayDTO
    {
        public required int Id { get; set; }
        public required string ApplicationUserId { get; set; }
        public required string Title { get; set; }
        public int? DurationSeconds { get; set; }
        public int? DurationMinutes { get; set; }
        public int? DurationHours { get; set; }
        public int? Sets { get; set; }
        public int? Reps { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string FriendsNotes { get; set; } = string.Empty;
        public string Steps { get; set; } = string.Empty;
    }
}
