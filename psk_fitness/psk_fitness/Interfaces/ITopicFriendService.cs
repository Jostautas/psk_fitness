using Microsoft.AspNetCore.Mvc;
using psk_fitness.Data;
using psk_fitness.DTOs;

namespace psk_fitness.Interfaces
{
    public interface ITopicFriendService
    {
        public Task<TopicFriendCreateDTO> AddTopicFriend(int topicId, string email);
        public Task<List<int>> GetAllAccessibleTopicsAsync(string userId);
    }
}
