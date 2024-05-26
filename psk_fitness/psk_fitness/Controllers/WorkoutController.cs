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
            Console.WriteLine("Server Controller create");
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

        [HttpGet("by-id/{id}")]
        public async Task<IActionResult> GetWorkoutById(int id)
        {
            var workout = await _workoutService.GetByIdAsync(id);
            
            if (workout == null)
            {
                return NotFound();
            }

            return Ok(workout);
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


    //    [HttpPut("update")]
    //    public async Task<IActionResult> UpdateWorkout([FromBody] WorkoutUpdateDTO workoutUpdateDto)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        try
    //        {
    //            var updateResult = await _workoutService.UpdateWorkoutAsync(workoutUpdateDto);
    //            if (updateResult)
    //            {
    //                return Ok(new { success = true, message = "Workout updated successfully." });
    //            }
    //            else
    //            {
    //                return NotFound(new { success = false, message = "Workout not found." });
    //           }
    //        }
    //        catch (Exception ex)
    //        {
                // Log the exception details here for debugging and error tracing
    //            return StatusCode(500, new { success = false, message = $"An error occurred while updating the workout. {ex.Message}" });
    //        }
    //    }
    }
}