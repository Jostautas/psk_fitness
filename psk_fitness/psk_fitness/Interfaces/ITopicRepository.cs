using psk_fitness.Data;
using psk_fitness.DTOs;

namespace psk_fitness.Interfaces;

public interface ITopicRepository
{
    Task<Topic> CreateTopicAsync(TopicCreateDTO topic, string userEmail);
    Task<List<Topic>> GetAllTopicsAsync(); 
    Task<List<TopicDisplayDTO>> GetAllTopicsToDisplayAsync();
    Task<List<TopicDisplayDTO>> GetUserTopicsToDisplayAsync(string userEmail);
}