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
    public async Task<IEnumerable<TopicDisplayDTO>> GetTopicsToDisplay()
    {
        return await _httpClient.GetFromJsonAsync<TopicDisplayDTO[]>($"{Constants.ApiEndpointPrefix}/topics");
    }

    public async Task<HttpResponseMessage> CreateTopicAsync(TopicCreateDTO topicCreateDTO, string userEmail)
    {
        var json = JsonSerializer.Serialize(topicCreateDTO);
        var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
        return await _httpClient.PostAsync($"{Constants.ApiEndpointPrefix}/topics?userEmail={userEmail}", stringContent);
    }
}