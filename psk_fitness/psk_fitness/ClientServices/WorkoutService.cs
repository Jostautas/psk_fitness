using psk_fitness.Data;
using psk_fitness.Interfaces.Services;
using psk_fitness.Interfaces;
using psk_fitness.DTOs.WorkoutDTOs;
using Microsoft.EntityFrameworkCore;
using BootstrapBlazor.Components;
using AutoMapper;

namespace psk_fitness.ClientServices
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IUserRepository _userRepository;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        
        public WorkoutService(IUserRepository userRepository, IWorkoutRepository workoutRepository, ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _workoutRepository = workoutRepository;
            _userRepository = userRepository;
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<Workout> CreateWorkoutAsync(WorkoutCreateDTO workout)
        {
            System.Console.WriteLine("Server service create");

            var selectedTopic = await _applicationDbContext.Topics
                .FirstOrDefaultAsync(t => t.Id == workout.TopicId);

            var selectedExercises = await _applicationDbContext.Exercise
                .Where(exercise => workout.ExreciseIds.Contains(exercise.Id))
                .ToListAsync();

            System.Console.WriteLine("Here are the exercises");

            foreach (var item in selectedExercises)
            {
                System.Console.WriteLine(item.Title);
            }

            if (selectedTopic == null)
            {
                throw new InvalidOperationException("Selected topic does not exist");
            }

            Workout newWorkout = new Workout
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
                Exercises = selectedExercises
            };

            return await _workoutRepository.CreateAsync(newWorkout);
        }

        public async Task<List<WorkoutForCalendarDTO>> GetWorkoutForCurrentMonth(int year, int month, string userEmail)
        {
            var userId = await _userRepository.GetUserByIdAsync(userEmail);
            List<Workout> workouts = await _workoutRepository.GetWorkoutForCurrentMonth(year, month, userId.Id);
            List<WorkoutForCalendarDTO> calendarWorkouts = _mapper.Map<List<WorkoutForCalendarDTO>>(workouts);

            return calendarWorkouts;
        }

        public async Task<WorkoutCreateDTO?> GetByIdAsync(int id)
        {
            Workout? workout = await _workoutRepository.GetByIdAsync(id);
            WorkoutCreateDTO? workoutCreateDTO = _mapper.Map<WorkoutCreateDTO>(workout);

            return workoutCreateDTO;
        }

    }

}
