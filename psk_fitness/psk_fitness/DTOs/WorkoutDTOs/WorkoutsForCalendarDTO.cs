namespace psk_fitness.DTOs.WorkoutDTOs
{
    public class WorkoutsForCalendarDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public TimeSpan? Duration {get; set;}
        public bool Finished { get; set; }
    }
}
