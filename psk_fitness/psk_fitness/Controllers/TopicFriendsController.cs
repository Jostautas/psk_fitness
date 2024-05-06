using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using psk_fitness.Data;
using System.Security.Claims;
using psk_fitness.Repositories;
using psk_fitness.Interfaces;


namespace psk_fitness.Controllers
{
    public class TopicFriendsController : Controller
    {
        private readonly ITopicFriendRepository _topicFriendRepository;
        public TopicFriendsController(ITopicFriendRepository topicFriendRepository)
        {
            _topicFriendRepository = topicFriendRepository;
        }

        [HttpPost("/addFriend/{topicId}")]
        public async Task<IActionResult> AddTopicFriend(int topicId, [FromBody] string email)
        {
            var response = await _topicFriendRepository.AddTopicFriend(email, topicId);

            if(response == null) { return BadRequest(); }

            return Created(String.Empty, response);
        }
    }
}
