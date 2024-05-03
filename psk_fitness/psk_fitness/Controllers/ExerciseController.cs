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
    }
}
