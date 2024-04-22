using System.ComponentModel.DataAnnotations;

namespace psk_fitness.Data
{
    public class TopicFriend
    {
        public required int TopicId { get; set; }
        public required string ApplicationUserId { get; set; }
        public bool ReadAndWrite { get; set; } = false;

        // Navigation properties to associate with Topic and ApplicationUser
        public required virtual Topic Topic { get; set; }
        public required virtual ApplicationUser ApplicationUser { get; set; }
    }
}
