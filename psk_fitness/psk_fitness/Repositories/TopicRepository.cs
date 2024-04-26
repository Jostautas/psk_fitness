using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using psk_fitness.Data;
using psk_fitness.DTOs;
using psk_fitness.Interfaces;

namespace psk_fitness.Repositories;

public class TopicRepository : ITopicRepository
{
    private ApplicationDbContext _applicationDbContext;
    private IMapper _mapper;


    public TopicRepository(ApplicationDbContext applicationDbContext, IMapper mapper) 
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
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

    public async Task<List<TopicDisplayDTO>> GetAllTopicsToDisplayAsync()
    {
        var topics = await GetAllTopicsAsync();
        return _mapper.Map<List<TopicDisplayDTO>>(topics);
    }
}