using psk_fitness.Data;
using psk_fitness.DTOs;
using psk_fitness.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using AutoMapper;
using psk_fitness.Components.Topics;

namespace psk_fitness.Repositories;

public class TopicFriendRepository : ITopicFriendRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly AuthenticationStateProvider? _authenticationStateProvider;
    private readonly IMapper _mapper;
    public TopicFriendRepository(ApplicationDbContext applicationDbContext, IMapper mapper, AuthenticationStateProvider authenticationStateProvider) {
        _applicationDbContext = applicationDbContext;
        _authenticationStateProvider = authenticationStateProvider;
        _mapper = mapper;
    }

    public async Task<TopicFriendCreateDTO?> AddTopicFriend(string email, int topicId)
    {
        var topic = await _applicationDbContext.Topics.FindAsync(topicId);
        if (topic == null) return null;
        var friend = await _applicationDbContext.Users
                                   .FirstOrDefaultAsync(u => u.Email == email);
        if (friend == null) return null;

        TopicFriend topicFriend = new()
        {
            TopicId = topicId,
            ApplicationUserId = friend.Id,
            ReadAndWrite = true,
            ApplicationUser = friend,
            Topic = topic,
        };

        _applicationDbContext.TopicFriends.Add(topicFriend);
        await _applicationDbContext.SaveChangesAsync();

        TopicFriendCreateDTO topicFriendDTO = new()
        {
            TopicId = topicFriend.TopicId,
            ApplicationUserId = topicFriend.ApplicationUserId,
            ReadAndWrite = topicFriend.ReadAndWrite,
        };

        return topicFriendDTO;
    }

    public async Task<List<int>?> GetAllAccessibleTopics(string userId)
    {
        var topicFriends = await _applicationDbContext.TopicFriends
            .Where(tf => tf.ApplicationUserId == userId)
            .ToListAsync();

        List<int> topicIds = topicFriends.Select(tf => tf.TopicId).ToList();

        return topicIds;
    }
}
