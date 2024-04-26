
using Microsoft.AspNetCore.Mvc;
using psk_fitness.Interfaces;
using psk_fitness.Data;
using psk_fitness.DTOs;

namespace psk_fitness.Controllers;

[ApiController]
[Route("[controller]")]
public class TopicController(ITopicRepository topicRepository) : Controller
{
    ITopicRepository _topicRepository = topicRepository;

    [HttpPost]
    public async Task<IActionResult> CreateTopicAsync([FromBody] TopicCreateDTO topic, string userEmail) 
    {
        await _topicRepository.CreateTopicAsync(topic, userEmail);
        return Ok(topic);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTopicsAsync()
    {
        var topics = await _topicRepository.GetAllTopicsToDisplayAsync();
        return Ok(topics);
    }
}