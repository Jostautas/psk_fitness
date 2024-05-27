namespace psk_fitness.DTOs.WorkoutDTOs
{
    public class WorkoutForCalendarDTO
    {
        public int Id { get; set; }
        public int Day { get; set; }
        public string Title { get; set; } = string.Empty;
        public TimeSpan? Duration {get; set;}
        public bool Finished { get; set; }
        public List<string> ExerciseTitles { get; set; } = new List<string>();

    }
}
