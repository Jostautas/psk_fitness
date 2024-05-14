using psk_fitness.Data;

namespace psk_fitness.Interfaces;

public interface ITopicRepository
{
    Task DeleteTopicAsync(Topic topic);
    Task AddTopicAsync(Topic topic);
    Task<List<Topic>> GetTopicsByUserIdAsync(string userId);
    Task<Topic> GetTopicById(int topicId);
    Task UpdateTopicAsync(Topic topic);
}