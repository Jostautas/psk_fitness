﻿using psk_fitness.Data;
using psk_fitness.DTOs;

namespace psk_fitness.Interfaces
{
    public interface IExerciseRepository
    {
        Task<List<ExerciseForWorkoutDTO>> GetExercisesForCreatingWorkout(string userEmail);
        Task<List<ExerciseForWorkoutDTO>> GetExercisesByWorkoutId(int workoutId);
        Task<List<ExerciseDisplayDTO>> GetExercisesForUser(string userEmail);
        Task<List<ExerciseDisplayDTO>> GetAllExercisesAsync();
        Task<ExerciseDisplayDTO> GetExerciseAsync(int id);
        Task<ExerciseDisplayDTO> AddExerciseAsync(ExerciseCreateDTO newExercise);
        Task<ExerciseDisplayDTO> UpdateExerciseAsync(int id, ExerciseCreateDTO updatedExercise);
        Task<ExerciseDisplayDTO> DeleteExerciseAsync(int id);
    }
}
