namespace psk_fitness.Entities
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string WorkoutId { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public TimeSpan Duration { get; set; } // Stores hours, minutes, and seconds
        public int Sets { get; set; }
        public int Reps { get; set; }
        private List<string> _steps = new List<string>();

        public string Steps
        {
            get => string.Join(";", _steps);
            set => _steps = value.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public bool IsExpanded { get; set; } = false;

        public Exercise()
        {

        }
    }
}
