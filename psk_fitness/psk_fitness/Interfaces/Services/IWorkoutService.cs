using psk_fitness.DTOs.WorkoutDTOs;
using psk_fitness.Data;

namespace psk_fitness.Interfaces.Services
{
    public interface IWorkoutService
    {
        Task<List<WorkoutForCalendarDTO>> GetWorkoutForCurrentMonth(int year, int month);
        Task<Workout> CreateWorkoutAsync(WorkoutCreateDTO workout);
    }
}
