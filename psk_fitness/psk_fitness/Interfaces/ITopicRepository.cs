using psk_fitness.Data;
using psk_fitness.DTOs;

namespace psk_fitness.Interfaces;

public interface ITopicRepository
{
    Task<Topic> CreateTopicAsync(TopicCreateDTO topic, string UserEmail);
    Task<List<Topic>> GetAllTopicsAsync(); 
    Task<List<TopicDisplayDTO>> GetAllTopicsToDisplayAsync();
}