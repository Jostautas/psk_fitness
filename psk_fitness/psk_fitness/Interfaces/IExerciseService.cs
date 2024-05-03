using psk_fitness.Data;

namespace psk_fitness.Interfaces
{
    public interface IExerciseService
    {
        Task<List<Exercise>> GetAllExercises();
        Task<Exercise> GetExercise(int id);
        Task<Exercise> AddExercise(Exercise newExercise);
        Task<Exercise> UpdateExercise(int id, Exercise updatedExercise);
        Task<Exercise> DeleteExercise(int id);
    }
}
