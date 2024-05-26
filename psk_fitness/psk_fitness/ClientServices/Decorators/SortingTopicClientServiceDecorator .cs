using psk_fitness.DTOs;
using psk_fitness.Interfaces;

namespace psk_fitness.ClientServices.Decorators
{
    public class SortingTopicClientServiceDecorator(ITopicClientService topicClientService) : ITopicClientServiceDecorator
    {
        private readonly ITopicClientService _topicClientService = topicClientService;

        public Task<HttpResponseMessage> CreateTopicAsync(TopicDTO topicCreateDTO, string userEmail)
        {
            return _topicClientService.CreateTopicAsync(topicCreateDTO, userEmail);
        }

        public Task<HttpResponseMessage> DeleteTopicAsync(int topicId)
        {
            return _topicClientService.DeleteTopicAsync(topicId);
        }

        public async Task<IEnumerable<TopicDTO>> GetUserTopicsAsync(string userEmail)
        {
            var topics = await _topicClientService.GetUserTopicsAsync(userEmail);
            return topics.OrderBy(topic => topic.Title);
        }

        public Task<HttpResponseMessage> UpdateTopicAsync(TopicDTO topicUpdateDTO)
        {
            return _topicClientService.UpdateTopicAsync(topicUpdateDTO);
        }
    }


}
