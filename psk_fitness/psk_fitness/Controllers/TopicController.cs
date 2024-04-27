
using Microsoft.AspNetCore.Mvc;
using psk_fitness.Interfaces;
using psk_fitness.DTOs;
using System.ComponentModel.DataAnnotations;
using psk_fitness.Properties;

namespace psk_fitness.Controllers;

[ApiController]
// TODO: interpolate psk_fitness.Properties.Constants.ApiEndpointPrefix in route
[Route("api/topics")]
public class TopicController(ITopicRepository _topicRepository) : Controller
{

    [HttpPost]
    public async Task<IActionResult> CreateTopicAsync([FromBody] TopicCreateDTO topic, [Required] string userEmail) 
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