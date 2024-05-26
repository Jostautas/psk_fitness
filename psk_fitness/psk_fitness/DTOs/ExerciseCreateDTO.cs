namespace psk_fitness.DTOs
{
    public class ExerciseCreateDTO
    {
        public string ApplicationUserId { get; set; }
        public string Title { get; set; }
        public int? DurationSeconds { get; set; }
        public int? DurationMinutes { get; set; }
        public int? DurationHours { get; set; }
        public int? Sets { get; set; }
        public int? Reps { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string Steps { get; set; } = string.Empty;

        public ExerciseCreateDTO()
        {
                
        }
    }
}
