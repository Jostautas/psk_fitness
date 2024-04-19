using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace psk_fitness.Data
{
    public class Topic
    {
        [Key] public int Id { get; set; }
        [ForeignKey("ApplicationUser")]
        public required string ApplicationUserId { get; set; }
        public required string Title { get; set; }
        public string? Color { get; set; }
        public string? Description { get; set; }
        public string? FriendsNotes { get; set; }

        public virtual required ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<TopicFriend>? TopicFriends { get; set; }


    }
}
