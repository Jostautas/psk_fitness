using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using psk_fitness.Data;
using psk_fitness.DTOs;
using psk_fitness.Interfaces;
using System.IO;

namespace psk_fitness.Repositories;

public class TopicRepository(ApplicationDbContext _applicationDbContext, IMapper _mapper) : ITopicRepository
{
    public async Task<Topic> CreateTopicAsync(TopicCreateDTO topicCreateDTO, string userEmail)
    {
        var topic = _mapper.Map<Topic>(topicCreateDTO);
        ApplicationUser? user = await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Email == userEmail)
            ?? throw new Exception("User not found.");
        topic.ApplicationUserId = user.Id;
        await _applicationDbContext.Topics.AddAsync(topic);
        await _applicationDbContext.SaveChangesAsync();
        return topic;
    }

    public async Task<List<Topic>> GetAllTopicsAsync()
    {
        return await _applicationDbContext.Topics.ToListAsync();
    }

    public async Task<List<TopicDisplayDTO>> GetAllTopicsToDisplayAsync()
    {
        var topics = await GetAllTopicsAsync();
        return _mapper.Map<List<TopicDisplayDTO>>(topics);
    }
}