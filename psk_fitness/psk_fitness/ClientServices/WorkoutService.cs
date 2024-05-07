using psk_fitness.Data;
using psk_fitness.Interfaces.Services;
using psk_fitness.Interfaces;
using psk_fitness.DTOs.WorkoutDTOs;
using Microsoft.EntityFrameworkCore;
using BootstrapBlazor.Components;

namespace psk_fitness.ClientServices
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly ApplicationDbContext _applicationDbContext;

        public WorkoutService(IWorkoutRepository workoutRepository, ApplicationDbContext applicationDbContext)
        {
            _workoutRepository = workoutRepository;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Workout> CreateWorkoutAsync(WorkoutCreateDTO workout)
        {

            // Check if the topic exists
            System.Console.WriteLine("kA1");
            var selectedTopic = await _applicationDbContext.Topics
                .FirstOrDefaultAsync(t => t.Id == workout.TopicId);
            System.Console.WriteLine("kA2");

            selectedTopic.Workouts = null;

            if (selectedTopic == null)
            {
                throw new InvalidOperationException("Selected topic does not exist");
            }

            Workout newWorkout = new Workout
            {
                Topic = selectedTopic,
                TopicId = workout.TopicId,
                Title = workout.Title,
                Date = DateOnly.FromDateTime(DateTime.Now),
                Description = workout.Description,
                FriendsNotes = workout.FriendsNotes,
                Notes = workout.Notes,
                Duration = workout.Duration,
                Finished = workout.Finished,
            };
            System.Console.WriteLine("kA3");

            return await _workoutRepository.CreateAsync(newWorkout);
        }
    }

}
