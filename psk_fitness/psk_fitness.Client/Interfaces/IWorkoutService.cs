using psk_fitness.Client.DTOs.WorkoutDTOs;

namespace psk_fitness.Client.Interfaces
{
    public interface IWorkoutService
    {
        Task<WorkoutCreateDTO> CreateWorkoutAsync(WorkoutCreateDTO workout);
    }
}
