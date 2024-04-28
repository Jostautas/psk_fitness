
using Microsoft.AspNetCore.Mvc;
using psk_fitness.Interfaces;
using psk_fitness.DTOs;
using System.ComponentModel.DataAnnotations;
using psk_fitness.Properties;
using System.Text.Json;
using System.Text;

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
    public async Task<IActionResult> GetDisplayTopicsAsync(string userEmail)
    {
        List<TopicDisplayDTO>? topics;
        // branch out for different "filtering" params
        if (userEmail == null) {
            topics = await _topicRepository.GetAllTopicsToDisplayAsync();
        }
        else {
            topics = await _topicRepository.GetUserTopicsToDisplayAsync(userEmail);
        }
        var json = JsonSerializer.Serialize(topics);
        return Content(json, "application/json", Encoding.UTF8);
    }
}