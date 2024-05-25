using psk_fitness.Data;
using psk_fitness.DTOs;

namespace psk_fitness.Interfaces;

public interface ITopicService
{
    Task<Topic> CreateTopicAsync(TopicDTO topic, string userEmail);
    Task<List<TopicDTO>> GetUserTopicsAsync(string userEmail);
    Task<List<TopicForWorkoutDTO>> GetTopicsForWorkout(string userEmail);
    Task DeleteTopicAsync(int topicId);
    Task UpdateTopicAsync(TopicDTO topicUpdateDTO);

}