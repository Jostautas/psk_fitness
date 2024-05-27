using psk_fitness.Data;
using psk_fitness.DTOs.WorkoutDTOs;

namespace psk_fitness.Interfaces
{
    public interface IWorkoutRepository
    {
        Task<Workout> CreateAsync(Workout workout);
        Task<Workout?> GetByDateAsync(DateOnly date);
        Task<List<Workout>> GetAllWourkoutsAsync();
        Task<Workout> UpdateAsync(int workoutId, Workout workout);
        Task<Workout?> GetByIdAsync(int workoutId);
        Task<List<Workout>> GetWorkoutForCurrentMonth(int year, int month, string userId);
    }
}