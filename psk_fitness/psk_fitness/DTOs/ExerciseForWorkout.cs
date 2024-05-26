using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace psk_fitness.DTOs
{
    public class ExerciseForWorkout
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
