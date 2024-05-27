using AutoMapper;
using psk_fitness.Client.DTOs.TopicDTOs;
using psk_fitness.Data;
using psk_fitness.DTOs;
using psk_fitness.Interfaces;

namespace psk_fitness.Services;

public class TopicService(
    ITopicRepository _topicRepository,
    IUserRepository _userRepository,
    IMapper _mapper) : ITopicService
{
    public async Task<Topic> CreateTopicAsync(TopicDTO topicCreateDTO, string userEmail)
    {
        var user = await _userRepository.GetUserByIdAsync(userEmail);
        var topic = _mapper.Map<Topic>(topicCreateDTO);
        topic.ApplicationUserId = user.Id;
        await _topicRepository.AddTopicAsync(topic);
        return topic;
    }

    public async Task<List<TopicForWorkoutDTO>> GetTopicsForWorkout(string userEmail)
    {
        var user = await _userRepository.GetUserByIdAsync(userEmail);
        var userTopics = await _topicRepository.GetTopicsByUserIdAsync(user.Id);
        
        var topicsForWorkout = _mapper.Map<List<TopicForWorkoutDTO>>(userTopics);
        return topicsForWorkout;
    }

    public async Task<List<TopicDTO>> GetUserTopicsAsync(string userEmail)
    {
        var user = await _userRepository.GetUserByIdAsync(userEmail);
        var userTopics = await _topicRepository.GetTopicsByUserIdAsync(user.Id);
        var userDisplayTopics = _mapper.Map<List<TopicDTO>>(userTopics);
        return userDisplayTopics;
    }

    public async Task DeleteTopicAsync(int topicId)
    {
        try
        {
            var topic = await _topicRepository.GetTopicById(topicId);
            await _topicRepository.DeleteTopicAsync(topic);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");

            throw;
        }
    }

    public async Task UpdateTopicAsync(TopicDTO topicUpdateDTO)
    {
        var topic = await _topicRepository.GetTopicById(topicUpdateDTO.Id);
        _mapper.Map(topicUpdateDTO, topic);
        await _topicRepository.UpdateTopicAsync(topic);
    }
}
