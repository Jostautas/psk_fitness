using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using psk_fitness.Data;
using psk_fitness.Interfaces;

namespace psk_fitness.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService exerciseService;
        public ExerciseController(IExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Exercise>>> GetAllExercises()
        {
            var dbExercises = await exerciseService.GetAllExercises();

            return Ok(dbExercises);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exercise>> GetExercise(int id)
        {
            var dbExercise = await exerciseService.GetExercise(id);
            if (dbExercise is null)
                return NotFound("Exercise not found.");

            return Ok(dbExercise);
        }

        [HttpPost]
        public async Task<ActionResult<Exercise>> AddExercise(Exercise newExercise)
        {
            var addedExercise = await exerciseService.AddExercise(newExercise);
            return Ok(addedExercise);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Exercise>> UpdateExercise(int id, Exercise updatedExercise)
        {
            var exercise = await exerciseService.UpdateExercise(id, updatedExercise);
            if (exercise == null)
                return NotFound("Exercise not found.");
            return Ok(exercise);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExercise(int id)
        {
            var deletedExercise = await exerciseService.DeleteExercise(id);
            if (deletedExercise == null)
                return NotFound("Exercise not found.");
            return Ok("Exercise was removed.");
        }
    }
}
