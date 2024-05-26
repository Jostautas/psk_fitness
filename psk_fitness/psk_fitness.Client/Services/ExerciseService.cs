using Newtonsoft.Json;
using psk_fitness.Client.DTOs.ExerciseDTOs;
using psk_fitness.Client.DTOs.TopicDTOs;
using psk_fitness.Client.Interfaces;
using System.Net.Http;

namespace psk_fitness.Client.Services
{
    public class ExerciseService : IExerciseService
    {

        private readonly HttpClient _httpClient;

        public ExerciseService(HttpClient httpClient) 
        { 
            _httpClient = httpClient;
        }

        public async Task<List<ExerciseForWorkoutDTO>> GetExercisesForWorkout(string userEmail)
        {
           var response = await _httpClient.GetAsync($"Exercise/for-workout/{userEmail}");
           response.EnsureSuccessStatusCode();

           var jsonString = await response.Content.ReadAsStringAsync();
           var exercises = JsonConvert.DeserializeObject<List<ExerciseForWorkoutDTO>>(jsonString);

           return exercises;
        }
    }
}
