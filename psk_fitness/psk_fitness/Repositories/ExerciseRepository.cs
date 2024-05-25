using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        private readonly IMapper mapper;

        public ExerciseRepository(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<ExerciseDisplayDTO>> GetExercisesByWorkoutId(int id)
        {
            var exercises = await context.Exercise.Where(e => e.WorkoutId == id).ToListAsync();
            var exercisesDTO = mapper.Map<List<ExerciseDisplayDTO>>(exercises);
            return exercisesDTO;
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
    }
}
