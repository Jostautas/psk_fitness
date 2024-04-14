﻿namespace psk_fitness.Entities
{
    public class SingleDayWorkout
    {
        public Guid Id { get; set; }
        public string WorkoutType { get; set; } = "Workout type";
        public int WorkoutStartHour { get; set; }
        public int WorkoutEndHour { get;set; }
        public int WorkoutStartMinute { get; set; }
        public int WorkoutEndMinute { get;set; }
        public string WorkoutNotes { get; set; } = string.Empty;

    }
}
