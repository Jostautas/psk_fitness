using psk_fitness.DTOs;

namespace psk_fitness.Interfaces;

public interface ITopicClientService
{

    Task<IEnumerable<TopicDTO>> GetUserTopicsAsync(string userEmail);
    Task<HttpResponseMessage> CreateTopicAsync(TopicDTO topicCreateDTO, string userEmail);
    Task<HttpResponseMessage> DeleteTopicAsync(int topicId);
    Task<HttpResponseMessage> UpdateTopicAsync(TopicDTO topicUpdateDTO);
}