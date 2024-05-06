using Microsoft.AspNetCore.Components;
using psk_fitness.DTOs;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using psk_fitness.Interfaces;
using psk_fitness.Data;
using psk_fitness.Properties;
using System.Text.Json;


namespace psk_fitness.ClientServices;

public class TopicFriendService(HttpClient _httpClient) : ITopicFriendService
{
    public async Task<List<int>> GetAllAccessibleTopicsAsync(string userId)
    {
        var TopicIdsToDisplay = await _httpClient.GetFromJsonAsync<List<int>>($"allAccessibleTopics/{userId}");
        if (TopicIdsToDisplay == null)
        {
            throw new Exception("Failed to load topics.");
        }

        return TopicIdsToDisplay;
    }
}
