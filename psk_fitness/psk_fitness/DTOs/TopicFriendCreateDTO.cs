using psk_fitness.Data;

namespace psk_fitness.DTOs
{
    public class TopicFriendCreateDTO
    {
        public required int TopicId { get; set; }
        public required string ApplicationUserId { get; set; }
        public bool ReadAndWrite { get; set; } = false;
    }
}
