using psk_fitness.Client.DTOs.WorkoutDTOs;

namespace psk_fitness.Client.Interfaces
{
    public interface IWorkoutService
    {
        Task<List<WorkoutForCalendarDTO>> GetByMonth(int year, int month, string userEmail);
        Task<WorkoutCreateDTO> CreateWorkoutAsync(WorkoutCreateDTO workout);
        Task<WorkoutCreateDTO> GetByIdAsync(int Id);
    }
}
