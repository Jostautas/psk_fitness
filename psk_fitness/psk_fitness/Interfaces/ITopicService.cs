using psk_fitness.DTOs;

namespace psk_fitness.Interfaces;

public interface ITopicService
{

    public Task<IEnumerable<TopicDisplayDTO>> GetUserDisplayTopicsAsync(string userEmail);
    public Task<HttpResponseMessage> CreateTopicAsync(TopicCreateDTO topicCreateDTO, string userEmail);
    public Task<HttpResponseMessage> DeleteTopicAsync(int topicId);
}