using Microsoft.AspNetCore.Components;
using psk_fitness.DTOs;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using psk_fitness.Interfaces;
using psk_fitness.Data;

namespace psk_fitness.ClientServices
{
    public class TopicFriendService(HttpClient _httpClient) : ITopicFriendService
    {
        public async Task<List<Topic>> GetAllAccessibleTopicsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Topic>>("allAccessibleTopics");
            if (response == null)
            {
                throw new Exception("Failed to load topics.");
            }
            return response;
        }
    }
}
