
using Microsoft.AspNetCore.Mvc;
using psk_fitness.Interfaces;
using psk_fitness.DTOs;
using System.ComponentModel.DataAnnotations;
using psk_fitness.Properties;
using System.Text.Json;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens;

namespace psk_fitness.Controllers;

[ApiController]
// TODO: interpolate psk_fitness.Properties.Constants.ApiEndpointPrefix in route
[Route("api/topics")]
public class TopicController(ITopicService _topicService) : Controller
{

    [HttpPost]
    public async Task<IActionResult> CreateTopicAsync([FromBody] TopicDTO topic, [Required] string userEmail) 
    {
        await _topicService.CreateTopicAsync(topic, userEmail);
        return Ok(topic);
    }

    [HttpGet]
    public async Task<IActionResult> GetDisplayTopicsAsync([Required] string userEmail)
    {
        var topics = await _topicService.GetUserTopicsAsync(userEmail);
        var json = JsonSerializer.Serialize(topics);
        return Content(json, "application/json", Encoding.UTF8);
    }

    [HttpGet("for-workout/{userEmail}")]
    public async Task<IActionResult> GetTopocsForWorkoutAsync([Required] string userEmail)
    {
        var topics = await _topicService.GetTopicsForWorkout(userEmail);
        var json = JsonSerializer.Serialize(topics);
        return Content(json, "application/json", Encoding.UTF8);
    }

    [HttpPut("{topicId}")]
    public async Task<IActionResult> UpdateTopicAsync([FromBody] TopicDTO topic, int topicId)
    {
        if (topic.Id != topicId)
        {
            return BadRequest("Invalid topic id.");
        }
        await _topicService.UpdateTopicAsync(topic);
        return Ok(topic.Id);
    }

    [HttpDelete("{topicId}")]
    public async Task<IActionResult> DeleteTopicAsync(int topicId)
    {
        await _topicService.DeleteTopicAsync(topicId);
        return Ok(topicId);
    }
}