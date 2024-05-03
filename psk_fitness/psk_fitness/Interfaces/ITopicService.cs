using psk_fitness.DTOs;

namespace psk_fitness.Interfaces;

public interface ITopicService
{

    public Task<IEnumerable<TopicDisplayDTO>> GetTopicsToDisplay();
}