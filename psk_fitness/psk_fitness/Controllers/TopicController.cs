
using Microsoft.AspNetCore.Mvc;
using psk_fitness.Interfaces;
using psk_fitness.Data;

namespace psk_fitness.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkoutController : Controller
{

    ITopicRepository _topicRepository;

    public WorkoutController(ITopicRepository topicRepository) 
    {
        _topicRepository = topicRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTopic([FromBody] Topic topic) 
    {
        await _topicRepository.CreateAsync(topic);
        return Ok(topic);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTopics()
    {
        var topics = await _topicRepository.GetAllTopicsAsync();
        return Ok(topics);
    }
}