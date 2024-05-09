using Newtonsoft.Json;
using psk_fitness.Client.DTOs.WorkoutDTOs;
using psk_fitness.Client.Interfaces;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace psk_fitness.Client.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly HttpClient _httpClient;

        public WorkoutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WorkoutCreateDTO> CreateWorkoutAsync(WorkoutCreateDTO workout) 
        {
            var response = await _httpClient.PostAsJsonAsync("api/Workout", workout);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<WorkoutCreateDTO>();
        }

        public async Task<List<WorkoutForCalendarDTO>> GetByMonth(int year, int month)
        {
            var response = await _httpClient.GetAsync($"api/Workout/by-month/{year}/{month}");
            response.EnsureSuccessStatusCode();
            
            var jsonString = await response.Content.ReadAsStringAsync();
            var workouts = JsonConvert.DeserializeObject<List<WorkoutForCalendarDTO>>(jsonString);

            return workouts;
        }

    }

}
