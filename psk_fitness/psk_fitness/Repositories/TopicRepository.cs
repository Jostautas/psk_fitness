using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using psk_fitness.Data;
using psk_fitness.Interfaces;

namespace psk_fitness.Repositories;

public class TopicRepository : ITopicRepository
{
    private ApplicationDbContext _applicationDbContext;

    public TopicRepository(ApplicationDbContext applicationDbContext) 
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Topic> CreateAsync(Topic topic)
    {
        await _applicationDbContext.Topics.AddAsync(topic);
        await _applicationDbContext.SaveChangesAsync();
        return topic;
    }

    public async Task<List<Topic>> GetAllTopicsAsync()
    {
        return await _applicationDbContext.Topics.ToListAsync();
    }
}