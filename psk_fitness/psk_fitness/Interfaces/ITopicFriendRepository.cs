using psk_fitness.Data;

namespace psk_fitness.Interfaces
{
    public interface ITopicFriendRepository
    {
        Task<TopicFriend?> AddTopicFriend(string email, int topicId);
        // Task<TopicFriend> RemoveTopicFriend(string ApplicationUserId, int TopicId);
        // Task<List<TopicFriend>> GetTopicFriends(int TopicId);
    }
}
