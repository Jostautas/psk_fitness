using psk_fitness.Data;

namespace psk_fitness.Interfaces;

public interface ITopicRepository
{
    Task<Topic> CreateAsync(Topic topic);
    Task<List<Topic>> GetAllTopicsAsync(); 
}