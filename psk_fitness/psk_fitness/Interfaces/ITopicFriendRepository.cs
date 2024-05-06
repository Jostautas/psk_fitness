using psk_fitness.Data;
using psk_fitness.DTOs;

namespace psk_fitness.Interfaces
{
    public interface ITopicFriendRepository
    {
        Task<TopicFriendCreateDTO?> AddTopicFriend(string email, int topicId);
        // Task<TopicFriend> RemoveTopicFriend(string ApplicationUserId, int TopicId);
        // Task<List<TopicFriend>> GetTopicFriends(int TopicId);
    }
}
