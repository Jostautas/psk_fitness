namespace psk_fitness.Client.DTOs.WorkoutDTOs
{
    public class WorkoutForCalendarDTO
    {
        public int Id { get; set; }
        public int Day { get; set; }
        public string Title { get; set; } = string.Empty;
        public TimeSpan? Duration {get; set;}
        public bool Finished { get; set; }
    }
}
