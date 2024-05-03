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
    }
}
