using System.Text.Json;
using AutoMapper;
using psk_fitness;
using psk_fitness.Data;
using psk_fitness.DTOs;
using psk_fitness.Properties;
using psk_fitness.Utilities;

namespace xUnitTests;

public class AutoMapperTest() {
    [Fact(Skip = "Playground code. Test not implemented.")]
    public void TopicCreateDTOIsMappedToTopic()
    {
        Mapper mapper = new (new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));
        var topicCreateDTO = new TopicCreateDTO {
            CssColor = new CssColor(CssColorMode.RGBA, (255, 150, 150).ToTuple()),
            Title = "test",
            Description = "test"
        };
        var topic = mapper.Map<Topic>(topicCreateDTO);
        var prettyPrintTopic = JsonSerializer.Serialize(topic, Constants.JsonSerializeOptions);
        Console.WriteLine("Topic from TopicCreateDTO: " + prettyPrintTopic);
        var topicCreateDTOFromTopic = mapper.Map<TopicCreateDTO>(topic);
        var prettyPrintTopicCreateDTOFromTopic = JsonSerializer.Serialize(topicCreateDTOFromTopic, Constants.JsonSerializeOptions);
        Console.WriteLine("TopicCreateDTO from Topic: " + prettyPrintTopicCreateDTOFromTopic);
    }
}
