using Microsoft.AspNetCore.Mvc;
using psk_fitness.Data;
using psk_fitness.DTOs.WorkoutDTOs;
using psk_fitness.Interfaces;
using psk_fitness.Interfaces.Services;

namespace psk_fitness.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutController : Controller
    {

        IWorkoutRepository _workoutRepository;
        IWorkoutService _workoutService;
        public WorkoutController(IWorkoutRepository workoutRepository, IWorkoutService workoutService)
        {
            _workoutRepository = workoutRepository;
            _workoutService = workoutService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkout([FromBody] WorkoutCreateDTO workout)
        {
            try
            {
                Workout createdWorkout = await _workoutService.CreateWorkoutAsync(workout);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("by-month/{year:int}/{month:int}")]
        public async Task<IActionResult> GetWorkoutForCurrentMonth(int year, int month)
        {

            List<WorkoutForCalendarDTO> workouts = await _workoutService.GetWorkoutForCurrentMonth(year, month);

            if (workouts == null || workouts.Count == 0)
            {
                return NotFound($"No workouts found for {month}/{year}.");
            }

            return Ok(workouts);

        }



        [HttpGet("by-date/{date}")]
        public async Task<IActionResult> GetWorkoutByDate(string date)
        {
            if (!DateOnly.TryParse(date, out DateOnly parsedDate))
            {
                return BadRequest("Invalid date format");
            }

            var workout = _workoutRepository.GetByDateAsync(parsedDate);
            if (workout == null)
            {
                return NotFound();
            }

            return Ok(workout);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllWorkouts()
        {
            var workouts = await _workoutRepository.GetAllWourkoutsAsync();
            return Ok(workouts);
        }
    }
}