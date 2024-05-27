using psk_fitness.Client.DTOs.TopicDTOs;

namespace psk_fitness.Client.Interfaces
{
    public interface ITopicService
    {
        Task<IEnumerable<TopicForWorkoutDTO>> GetTopicsForWorkout(string userEmail);
    }
}
