using psk_fitness.Client.DTOs.WorkoutDTOs;
using psk_fitness.Client.Interfaces;
using System.Net.Http.Json;

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
    }

}
