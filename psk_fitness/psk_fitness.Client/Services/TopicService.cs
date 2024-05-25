using Newtonsoft.Json;
using psk_fitness.Client.DTOs.TopicDTOs;
using psk_fitness.Client.DTOs.WorkoutDTOs;
using psk_fitness.Client.Interfaces;

namespace psk_fitness.Client.Services
{
    public class TopicService : ITopicService
    {
        private readonly HttpClient _httpClient;

        public TopicService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<TopicForWorkoutDTO>> GetTopicsForWorkout(string userEmail)
        {
            Console.WriteLine("UI service get");
            var response = await _httpClient.GetAsync($"api/topics/for-workout/{userEmail}");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var topics = JsonConvert.DeserializeObject<List<TopicForWorkoutDTO>>(jsonString);

            return topics;
        }
    }
}
