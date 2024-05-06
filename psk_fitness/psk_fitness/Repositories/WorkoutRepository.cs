using AutoMapper;
using BootstrapBlazor.Components;
using Microsoft.EntityFrameworkCore;
using psk_fitness.Data;
using psk_fitness.DTOs;
using psk_fitness.DTOs.WorkoutDTOs;
using psk_fitness.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace psk_fitness.Repositories
{
    public class WorkoutRepository(ApplicationDbContext _applicationDbContext, IMapper _mapper) : IWorkoutRepository
    {

        public async Task<Workout> CreateAsync(WorkoutCreateDTO workout)
        {

            var selectedTopic = await _applicationDbContext.Topics.FirstOrDefaultAsync(t => workout.TopicId == t.Id);

            if (selectedTopic is null)
            {
                throw new Exception("Selected topic does not exist");
            }

            Workout newWorkout = new Workout()
            {
                Topic = selectedTopic,
                TopicId = workout.TopicId,
                Title = workout.Title,
                Date = workout.Date,
                Description = workout.Description,
                FriendsNotes = workout.FriendsNotes,
                Notes = workout.Notes,
                Duration = workout.Duration,
                Finished = workout.Finished,
            };

            await _applicationDbContext.Workouts.AddAsync(newWorkout);
            await _applicationDbContext.SaveChangesAsync();

            return newWorkout;
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

        public Task<List<WorkoutsForCalendarDTO>> GetWorkoutsForCalendar()
        {
            throw new NotImplementedException();
        }


    }
}