using Microsoft.AspNetCore.Mvc;
using psk_fitness.Data;
using psk_fitness.DTOs.WorkoutDTOs;
using psk_fitness.Interfaces;

namespace psk_fitness.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkoutController : Controller
    {

        IWorkoutRepository _workoutRepository;

        public WorkoutController(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkout([FromBody] WorkoutCreateDTO workout)
        {

            try
            {
                await _workoutRepository.CreateAsync(workout);
            }catch (Exception ex)
            {

            }

            return Ok(workout);
        }

        [HttpGet("{date}")]
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