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
    public async Task<List<int>> GetAllAccessibleTopicsAsync()
    {
        //var response = await _httpClient.GetFromJsonAsync<List<Topic>>($"{Constants.ApiEndpointPrefix}/allAccessibleTopics");
        //if (response == null)
        //{
        //    throw new Exception("Failed to load topics.");
        //}

        var response = await _httpClient.GetAsync($"allAccessibleTopics");
        Console.WriteLine("response:");
        Console.WriteLine(response);

        var json = await response.Content.ReadAsStringAsync();
        var TopicIdsToDisplay = JsonSerializer.Deserialize<List<int>>(json);
        return TopicIdsToDisplay;
    }
}
