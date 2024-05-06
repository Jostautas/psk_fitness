using Microsoft.AspNetCore.Components;
using psk_fitness.DTOs;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using psk_fitness.Interfaces;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Text;
using psk_fitness.Properties;

namespace psk_fitness.ClientServices;
public class TopicService(HttpClient _httpClient) : ITopicService
{
    public async Task<IEnumerable<TopicDisplayDTO>> GetUserDisplayTopicsAsync(string userEmail)
    {
        var response = await _httpClient.GetAsync($"{Constants.ApiEndpointPrefix}/topics?userEmail={userEmail}");
        var json = await response.Content.ReadAsStringAsync();
        var topicsToDisplay = JsonSerializer.Deserialize<List<TopicDisplayDTO>>(json);
        return topicsToDisplay;
    }

    public async Task<HttpResponseMessage> CreateTopicAsync(TopicCreateDTO topicCreateDTO, string userEmail)
    {
        var json = JsonSerializer.Serialize(topicCreateDTO);
        var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
        return await _httpClient.PostAsync($"{Constants.ApiEndpointPrefix}/topics?userEmail={userEmail}", stringContent);
    }
}