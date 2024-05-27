using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace psk_fitness.Data
{
    public class Exercise
    {
        [Key] public int Id { get; set; }
        [ForeignKey("ApplicationUser")]
        public required string ApplicationUserId { get; set; }
        public required string Title { get; set; }
        public TimeSpan? Duration { get; set; }
        public int? Sets { get; set; }
        public int? Reps { get; set; }
        public string Description { get; set; } = "";
        public string Notes { get; set; } = "";
        public string FriendsNotes { get; set; } = "";
        public string Steps { get; set; } = "";
        public virtual required ApplicationUser ApplicationUser { get; set; }
    }
}
