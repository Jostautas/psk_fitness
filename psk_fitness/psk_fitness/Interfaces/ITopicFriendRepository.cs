using psk_fitness.Data;
<<<<<<< HEAD
=======
using psk_fitness.DTOs;
using psk_fitness.Migrations;
>>>>>>> main

namespace psk_fitness.Interfaces
{
    public interface ITopicFriendRepository
    {
        Task<TopicFriendCreateDTO?> AddTopicFriend(string email, int topicId);
        // Task<TopicFriend> RemoveTopicFriend(string ApplicationUserId, int TopicId);
        // Task<List<TopicFriend>> GetTopicFriends(int TopicId);
    }
}
