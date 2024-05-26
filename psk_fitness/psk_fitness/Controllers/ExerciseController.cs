using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using psk_fitness.Data;
using psk_fitness.DTOs;
using psk_fitness.Interfaces;

namespace psk_fitness.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseRepository exerciseService;
        public ExerciseController(IExerciseRepository exerciseService)
        {
            this.exerciseService = exerciseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ExerciseDisplayDTO>>> GetAllExercisesAsync()
        {
            var exercises = await exerciseService.GetAllExercisesAsync();

            return Ok(exercises);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExerciseDisplayDTO>> GetExerciseAsync(int id)
        {
            var exercise = await exerciseService.GetExerciseAsync(id);
            if (exercise is null)
                return NotFound("Exercise not found.");

            return Ok(exercise);
        }

        [HttpGet("for-workout/{userEmail}")]
        public async Task<ActionResult<List<ExerciseForWorkoutDTO>>> GetExerciseForWorkout([FromRoute] string userEmail)
        {
            Console.WriteLine("Request is correct");
            var exercises = await exerciseService.GetExercisesForWorkout(userEmail);
            if (exercises is null)
                return NotFound("Exercise not found.");

            return Ok(exercises);
        }

        [HttpPost]
        public async Task<ActionResult<ExerciseDisplayDTO>> AddExerciseAsync(ExerciseCreateDTO newExercise)
        {
            var addedExercise = await exerciseService.AddExerciseAsync(newExercise);
            return Ok(addedExercise);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ExerciseDisplayDTO>> UpdateExerciseAsync(int id, ExerciseCreateDTO updatedExercise)
        {
            var exercise = await exerciseService.UpdateExerciseAsync(id, updatedExercise);
            if (exercise == null)
                return NotFound("Exercise not found.");
            return Ok(exercise);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExerciseAsync(int id)
        {
            var deletedExercise = await exerciseService.DeleteExerciseAsync(id);
            if (deletedExercise == null)
                return NotFound("Exercise not found.");
            return Ok("Exercise was removed.");
        }


    }
}
