using Microsoft.AspNetCore.Components;
using psk_fitness.DTOs;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using psk_fitness.Interfaces;
using psk_fitness.Data;
using psk_fitness.Properties;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System.Text;


namespace psk_fitness.ClientServices;

public class TopicFriendService(HttpClient _httpClient) : ITopicFriendService
{
    public async Task<TopicFriendCreateDTO> AddTopicFriend(int topicId, string email)
    {
        Console.WriteLine("Service input:" + topicId + " " + email);
        HttpContent content = new StringContent(JsonSerializer.Serialize(email), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"/addFriend/{topicId}", content);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to add friend. Status code: {response.StatusCode}");
        }

        var newFriend = await response.Content.ReadFromJsonAsync<TopicFriendCreateDTO>();
        if (newFriend == null) throw new Exception("Failed to add friend.");

        return newFriend;
    }
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
