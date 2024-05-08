﻿using psk_fitness.Data;
using psk_fitness.DTOs.WorkoutDTOs;

namespace psk_fitness.Interfaces
{
    public interface IWorkoutRepository
    {
        Task<Workout> CreateAsync(WorkoutCreateDTO workout);
        Task<Workout?> GetByDateAsync(DateOnly date);
        Task<List<Workout>> GetAllWourkoutsAsync();
    }
}