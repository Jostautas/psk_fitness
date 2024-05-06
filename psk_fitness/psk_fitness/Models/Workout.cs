// THIS IS TEMPORARY FILE ONLY FOR TESTING. THIS WHOLE "MODELS" FOLDER WILL BE DELETED 

namespace psk_fitness.Models;

public class Workout
{
    public Guid Id { get; set; }
    public string WorkoutType { get; set; } = "Workout type";
    public int WorkoutStartHour { get; set; }
    public int WorkoutEndHour { get;set; }
    public int WorkoutStartMinute { get; set; }
    public int WorkoutEndMinute { get;set; }
    public string WorkoutNotes { get; set; } = string.Empty;
    public bool Finished { get; set; } = false;
    public DateTime Date { get; set; }

}
