using psk_fitness.Data;

namespace psk_fitness.Interfaces
{
    public interface ITopicFriendService
    {
        public Task<List<int>> GetAllAccessibleTopicsAsync();
    }
}
