using System.Text.Json;

namespace psk_fitness.Properties;

public static class Constants
{
    public static readonly JsonSerializerOptions JsonSerializeOptions = new()
    {
        WriteIndented = true
    };
    public static readonly string BaseHttpUri = "http://localhost:5197";
    public static readonly string ApiEndpointPrefix = "api";
    public static readonly string RegisteredUserTestEmail = "example@gmail.com";
}