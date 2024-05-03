using Microsoft.EntityFrameworkCore;
using psk_fitness.Data;
using psk_fitness.Interfaces;

namespace psk_fitness.Repositories
{
    public class ExerciseService : IExerciseService
    {
        private readonly ApplicationDbContext context;

        public ExerciseService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Exercise>> GetAllExercises()
        {
            var exercises = await context.Exercise.ToListAsync();
            return exercises;
        }

        public async Task<Exercise> GetExercise(int id)
        {
            var exercise = await context.Exercise.FindAsync(id);
            return exercise;
        }

        public async Task<Exercise> AddExercise(Exercise newExercise)
        {
            context.Exercise.Add(newExercise);
            await context.SaveChangesAsync();
            return newExercise;
        }

        public async Task<Exercise> UpdateExercise(int id, Exercise updatedExercise)
        {
            var existingExercise = await context.Exercise.FindAsync(id);
            if (existingExercise != null)
            {
                context.Entry(existingExercise).CurrentValues.SetValues(updatedExercise);
                await context.SaveChangesAsync();
            }
            return existingExercise;
        }

        public async Task<Exercise> DeleteExercise(int id)
        {
            var exercise = await context.Exercise.FindAsync(id);
            if (exercise != null)
            {
                context.Exercise.Remove(exercise);
                await context.SaveChangesAsync();
            }
            return exercise;
        }
    }
}
