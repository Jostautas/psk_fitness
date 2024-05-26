using AutoMapper;
using Microsoft.EntityFrameworkCore;
using psk_fitness.Components;
using psk_fitness.Components.Exercises.Pages;
using psk_fitness.Components.Topics;
using psk_fitness.Data;
using psk_fitness.DTOs;
using psk_fitness.Interfaces;

namespace psk_fitness.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IUserRepository _userRepository;
        private readonly IMapper mapper;


        public ExerciseRepository(ApplicationDbContext context, IUserRepository userRepository, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            _userRepository = userRepository;
        }



        public async Task<List<ExerciseDisplayDTO>> GetAllExercisesAsync()
        {
            var exercises = await context.Exercise.ToListAsync();
            //var exerciseDTOS = exercises.Select(exercise => mapper.Map<ExerciseDisplayDTO>(exercise));
            return mapper.Map<List<ExerciseDisplayDTO>>(exercises);
        }

        public async Task<ExerciseDisplayDTO> GetExerciseAsync(int id)
        {
            var exercise = await context.Exercise.FindAsync(id);
            var exerciseDTO = mapper.Map<ExerciseDisplayDTO>(exercise);
            return exerciseDTO;
        }

        public async Task<ExerciseDisplayDTO> AddExerciseAsync(ExerciseCreateDTO newExercise)
        {
            Exercise exercise = mapper.Map<Exercise>(newExercise);
            context.Exercise.Add(exercise);
            await context.SaveChangesAsync();
            return mapper.Map<ExerciseDisplayDTO>(exercise);
        }

        public async Task<ExerciseDisplayDTO> UpdateExerciseAsync(int id, ExerciseCreateDTO updatedExercise)
        {
            var existingExercise = await context.Exercise.FindAsync(id);
            if (existingExercise != null)
            {
                context.Entry(existingExercise).CurrentValues.SetValues(updatedExercise);
                await context.SaveChangesAsync();
            }
            return mapper.Map<ExerciseDisplayDTO>(existingExercise);
        }

        public async Task<ExerciseDisplayDTO> DeleteExerciseAsync(int id)
        {
            var exercise = await context.Exercise.FindAsync(id);
            if (exercise != null)
            {
                context.Exercise.Remove(exercise);
                await context.SaveChangesAsync();
            }
            return mapper.Map<ExerciseDisplayDTO>(exercise);
        }

        public async Task<List<ExerciseDisplayDTO>> GetExercisesForUser(string userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            var exercises = await context.Exercise.Where(t => t.ApplicationUserId.Equals(user.Id)).ToListAsync();
            return mapper.Map<List<ExerciseDisplayDTO>>(exercises);
        }

        public async Task<List<ExerciseForWorkoutDTO>> GetExercisesForWorkout(string userEmail)
        {
            var user = await _userRepository.GetUserByIdAsync(userEmail);
            var exercises = await context.Exercise.Where(t => t.ApplicationUserId.Equals(user.Id)).ToListAsync();
            return mapper.Map<List<ExerciseForWorkoutDTO>>(exercises);
        }

        public async Task<List<ExerciseForWorkoutDTO>> GetExercisesByWorkoutId(int workoutId)
        {
            
            var exercises = await context.Workouts
                .Where(w => w.Id == workoutId)
                .SelectMany(w => w.Exercises)
            .ToListAsync();

            return mapper.Map<List<ExerciseForWorkoutDTO>>(exercises);   
        }
    }
}
