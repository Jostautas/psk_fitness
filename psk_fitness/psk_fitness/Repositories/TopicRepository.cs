using Microsoft.EntityFrameworkCore;
using psk_fitness.Data;
using psk_fitness.Interfaces;

namespace psk_fitness.Repositories;

public class TopicRepository(ApplicationDbContext _applicationDbContext) : ITopicRepository
{
    public async Task AddTopicAsync(Topic topic)
    {
        await _applicationDbContext.Topics.AddAsync(topic);
        await _applicationDbContext.SaveChangesAsync();
    }

    public async Task<Topic> GetTopicById(int topicId)
    {


        try
        {
            return await _applicationDbContext.Topics.FirstOrDefaultAsync(t => t.Id.Equals(topicId))
                ?? throw new Exception("Topic not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }

    public async Task<List<Topic>> GetTopicsByUserIdAsync(string userId)
    {
        return await _applicationDbContext.Topics.Where(t => t.ApplicationUserId.Equals(userId)).ToListAsync();
    }

    public async Task DeleteTopicAsync(Topic topic)
    {
        _applicationDbContext.Topics.Remove(topic);
        await _applicationDbContext.SaveChangesAsync();
    }

    public async Task UpdateTopicAsync(Topic topic)
    {
        _applicationDbContext.Topics.Update(topic);
        await _applicationDbContext.SaveChangesAsync();
    }

    public async Task DeleteTopicAsync(int topicId)
    {
        try
        {
            var topic = await _applicationDbContext.Topics.FirstOrDefaultAsync(t => t.Id == topicId)
                ?? throw new Exception("Topic not found.");
            _applicationDbContext.Topics.Remove(topic);
            await _applicationDbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }
}