using psk_fitness.Data;
using psk_fitness.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace psk_fitness.Repositories
{
    public class TopicFriendRepository : ITopicFriendRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly AuthenticationStateProvider? _authenticationStateProvider;
        public TopicFriendRepository(ApplicationDbContext applicationDbContext, AuthenticationStateProvider authenticationStateProvider) {
            _applicationDbContext = applicationDbContext;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<TopicFriend?> AddTopicFriend(string email, int topicId)
        {
            if (_authenticationStateProvider is null || _applicationDbContext is null)
            {
                return null;
            }

            Console.WriteLine("HERE");

            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var userClaimsPrincipal = authState.User;

            if (userClaimsPrincipal.Identity is null || userClaimsPrincipal.Identity.IsAuthenticated!)
            {
                return null;
            }
            var currentUserId = userClaimsPrincipal.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var topic = await _applicationDbContext.Topics.FindAsync(topicId);
            if (topic == null)
                return null;
            if (topic.ApplicationUserId != currentUserId)
                return null;

            var friend = await _applicationDbContext.Users
                                       .FirstOrDefaultAsync(u => u.Email == email);
            if (friend == null)
                return null;

            var topicFriend = new TopicFriend
            {
                TopicId = topicId,
                ApplicationUserId = friend.Id,
                ReadAndWrite = true,
                ApplicationUser = friend,
                Topic = topic,
            };

            _applicationDbContext.TopicFriends.Add(topicFriend);
            await _applicationDbContext.SaveChangesAsync();

            return topicFriend;
        }

    }
}
