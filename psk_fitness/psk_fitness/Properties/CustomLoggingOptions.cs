namespace psk_fitness.Properties;

public class CustomLoggingOptions
{
    public const string SectionName = "LoggingSettings";
    public bool LoggingEnabled { get; set; } = true;
    public string LogPath { get; set; } = "Logs/log.log";
}