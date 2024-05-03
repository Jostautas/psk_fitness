using psk_fitness.Data;

namespace psk_fitness.Interfaces
{
    public interface IExerciseService
    {
        Task<List<Exercise>> GetAllExercises();

    }
}
