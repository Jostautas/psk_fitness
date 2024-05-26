using psk_fitness.Client.DTOs.ExerciseDTOs;
using psk_fitness.Client.DTOs.TopicDTOs;

namespace psk_fitness.Client.Interfaces
{
    public interface IExerciseService
    {
        Task<List<ExerciseForWorkoutDTO>> GetExercisesForCalendar(int workoutId);

        Task<List<ExerciseForWorkoutDTO>> GetExercisesForWorkout(string userEmail);
    }
}
