﻿using Newtonsoft.Json;
using psk_fitness.Client.DTOs.WorkoutDTOs;
using psk_fitness.Client.Interfaces;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace psk_fitness.Client.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly HttpClient _httpClient;

        public WorkoutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WorkoutCreateDTO> CreateWorkoutAsync(WorkoutCreateDTO workout) 
        {
            Console.WriteLine("UI service create");
            Console.WriteLine("UI service ids");
            foreach (var w in workout.ExerciseIds)
            {
                Console.WriteLine(w);
            }

            var response = await _httpClient.PostAsJsonAsync("api/Workout", workout);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<WorkoutCreateDTO>();
        }

        public async Task<List<WorkoutForCalendarDTO>> GetByMonth(int year, int month, string userEmail)
        {
            var response = await _httpClient.GetAsync($"api/Workout/by-month/{year}/{month}/{userEmail}");
            response.EnsureSuccessStatusCode();
            
            var jsonString = await response.Content.ReadAsStringAsync();
            var workouts = JsonConvert.DeserializeObject<List<WorkoutForCalendarDTO>>(jsonString);

            return workouts;
        }

        public async Task<WorkoutCreateDTO> GetByIdAsync(int Id)
        {
            var response = await _httpClient.GetAsync($"api/Workout/by-id/{Id}");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var workout = JsonConvert.DeserializeObject<WorkoutCreateDTO>(jsonString);

            return workout;
        }

        public async Task<WorkoutUpdateDTO> UpdateById(int id, WorkoutUpdateDTO workout)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Workout/update", workout);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<WorkoutUpdateDTO>();
        }

    }

}
