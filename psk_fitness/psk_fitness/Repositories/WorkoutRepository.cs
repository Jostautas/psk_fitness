using AutoMapper;
using Microsoft.EntityFrameworkCore;
using psk_fitness.Data;
using psk_fitness.DTOs.WorkoutDTOs;
using psk_fitness.Interfaces;

namespace psk_fitness.Repositories
{
    public class WorkoutRepository(ApplicationDbContext _applicationDbContext, IMapper _mapper) : IWorkoutRepository
    {

        public async Task<Workout> CreateAsync(Workout workout)
        {

            await _applicationDbContext.Workouts.AddAsync(workout);

            await _applicationDbContext.SaveChangesAsync();

            return workout;
        }

        public async Task<List<Workout>> GetAllWourkoutsAsync()
        {
            var workouts = await _applicationDbContext.Workouts.ToListAsync();
            return workouts;
        }

        public async Task<Workout?> GetByDateAsync(DateOnly date)
        {
            var workout = await _applicationDbContext.Workouts.FirstOrDefaultAsync(w => w.Date == date);
            return workout;
        }

        public async Task<Workout?> GetByIdAsync(int workoutId)
        {
            var workout = await _applicationDbContext.Workouts.FirstOrDefaultAsync(w => w.Id == workoutId);
            return workout;
        }

        public async Task<Workout> UpdateAsync(int workoutId, Workout updatedWorkout)
        {
            var workout = await _applicationDbContext.Workouts.FindAsync(updatedWorkout.Id);
            if (workout == null)
            {
                throw new Exception("Selected workout does not exist");
            }

            _applicationDbContext.Entry(workout).CurrentValues.SetValues(updatedWorkout);
            await _applicationDbContext.SaveChangesAsync();

            return workout;
        }

        public async Task<List<Workout>> GetWorkoutForCurrentMonth(int year, int month)
        {
            var startDate = new DateOnly(year, month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            var workouts = await _applicationDbContext.Workouts
                            .Where(w => w.Date >= startDate && w.Date <= endDate)
                            .ToListAsync();

            return workouts;
        }

    }
}