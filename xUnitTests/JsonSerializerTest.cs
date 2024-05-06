using System.Text;
using System.Text.Json;
using psk_fitness.Utilities;
using psk_fitness.DTOs;

namespace xUnitTests;

public class JsonSerializerTest() {
    [Fact(Skip = "Playground code. Test not implemented.")]
    public void CssColorIsSerializedAndDeserialized()
    {
        var color = new CssColor(CssColorMode.HSLA, (11, 11, 11).ToTuple());
        var topicCreateDTO = new TopicCreateDTO {
            CssColor = new CssColor(CssColorMode.RGBA, (255, 150, 150).ToTuple()),
            Title = "test",
            Description = "test"
        };
        var options = new JsonSerializerOptions
        {
            // IncludeFields = true,
            WriteIndented = true
        };
        var json = JsonSerializer.Serialize(topicCreateDTO, options);
        var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
        Console.WriteLine(json);
        Console.WriteLine(JsonSerializer.Deserialize<TopicCreateDTO>(json).CssColor);
        Console.WriteLine(stringContent.Headers.ToString());
    }
}
