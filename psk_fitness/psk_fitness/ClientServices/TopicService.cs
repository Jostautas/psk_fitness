using Microsoft.AspNetCore.Components;
using psk_fitness.DTOs;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using psk_fitness.Interfaces;

namespace psk_fitness.ClientServices;
public class TopicService(HttpClient _httpClient) : ITopicService
{
    public async Task<IEnumerable<TopicDisplayDTO>> GetTopicsToDisplay()
    {
        return await _httpClient.GetFromJsonAsync<TopicDisplayDTO[]>("topic");
    }
}