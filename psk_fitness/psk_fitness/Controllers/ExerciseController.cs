using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using psk_fitness.Data;

namespace psk_fitness.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public ExerciseController(ApplicationDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Exercise>>> GetAllExercises()
        {
            var dbExercises = await context.Exercise.ToListAsync();

            return Ok(dbExercises);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exercise>> GetExercise(int id)
        {
            var dbExercise = await context.Exercise.FindAsync(id);
            if (dbExercise is null)
                return NotFound("Exercise not found.");

            return Ok(dbExercise);
        }

        [HttpPost]
        public async Task<ActionResult<Exercise>> AddExercise(Exercise newExercise)
        {
            context.Exercise.Add(newExercise);

            await context.SaveChangesAsync();

            return Ok(newExercise);
        }

        [HttpPut]
        public async Task<ActionResult<Exercise>> UpdateExercise(Exercise updatedExercise)
        {
            var dbExercise = await context.Exercise.FindAsync(updatedExercise.Id);
            if (dbExercise is null)
                return NotFound("Exercise not found.");

            dbExercise = updatedExercise;

            await context.SaveChangesAsync();

            return Ok(dbExercise);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExercise(int id)
        {
            var dbHero = await context.Exercise.FindAsync(id);
            if (dbHero is null)
                return NotFound("Exercise not found.");

            context.Exercise.Remove(dbHero);
            await context.SaveChangesAsync();

            return Ok("Exercise was removed.");
        }
    }
}
