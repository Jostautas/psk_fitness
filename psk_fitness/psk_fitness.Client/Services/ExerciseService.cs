using Newtonsoft.Json;
using psk_fitness.Client.DTOs.ExerciseDTOs;
using psk_fitness.Client.DTOs.TopicDTOs;
using System.Net.Http;

namespace psk_fitness.Client.Services
{
    public class ExerciseService
    {

        private readonly HttpClient _httpClient;

        public ExerciseService(HttpClient httpClient) 
        { 
            _httpClient = httpClient;
        }

        //public async Task<IEnumerable<ExerciseForWorkoutDTO>> GetExercisesForWorkout(string userEmail)
        //{
        //   var response = await _httpClient.GetAsync($"Exercise");
        //    response.EnsureSuccessStatusCode();

        //    var jsonString = await response.Content.ReadAsStringAsync();
        //    var topics = JsonConvert.DeserializeObject<List<TopicForWorkoutDTO>>(jsonString);

        //    return topics;
        //}
    }
}
