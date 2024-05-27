using psk_fitness.DTOs;
using psk_fitness.Interfaces;
using System.Text.Json;
using System.Text;
using psk_fitness.Properties;

namespace psk_fitness.ClientServices;
public class TopicClientService(HttpClient _httpClient) : ITopicClientService
{
    public async Task<IEnumerable<TopicDTO>> GetUserTopicsAsync(string userEmail)
    {
        var response = await _httpClient.GetAsync($"{Constants.ApiEndpointPrefix}/topics?userEmail={userEmail}");
        var stream = response.Content.ReadAsStream();
        string json;
        using (StreamReader reader = new(stream))
        {
            json = reader.ReadToEnd();
        }
        var topicsDTO = JsonSerializer.Deserialize<List<TopicDTO>>(json);
        return topicsDTO;
    }

    public async Task<HttpResponseMessage> CreateTopicAsync(TopicDTO topicCreateDTO, string userEmail)
    {
        var json = JsonSerializer.Serialize(topicCreateDTO);
        var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
        return await _httpClient.PostAsync($"{Constants.ApiEndpointPrefix}/topics?userEmail={userEmail}", stringContent);
    }

    public async Task<HttpResponseMessage> DeleteTopicAsync(int topicId)
    {
        return await _httpClient.DeleteAsync($"{Constants.ApiEndpointPrefix}/topics/{topicId}");
    }

    public async Task<HttpResponseMessage> UpdateTopicAsync(TopicDTO topicUpdateDTO)
    {
        var json = JsonSerializer.Serialize(topicUpdateDTO);
        var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
        return await _httpClient.PutAsync($"{Constants.ApiEndpointPrefix}/topics/{topicUpdateDTO.Id}", stringContent);
    }
}