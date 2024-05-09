﻿using psk_fitness.Data;
using psk_fitness.Interfaces.Services;
using psk_fitness.Interfaces;
using psk_fitness.DTOs.WorkoutDTOs;
using Microsoft.EntityFrameworkCore;
using BootstrapBlazor.Components;
using AutoMapper;

namespace psk_fitness.ClientServices
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        
        public WorkoutService(IWorkoutRepository workoutRepository, ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _workoutRepository = workoutRepository;
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<Workout> CreateWorkoutAsync(WorkoutCreateDTO workout)
        {

            var selectedTopic = await _applicationDbContext.Topics
                .FirstOrDefaultAsync(t => t.Id == workout.TopicId);

            selectedTopic.Workouts = null;

            if (selectedTopic == null)
            {
                throw new InvalidOperationException("Selected topic does not exist");
            }

            Workout newWorkout = new Workout
            {
                Topic = selectedTopic,
                TopicId = workout.TopicId,
                Title = workout.Title,
                Date = DateOnly.FromDateTime(DateTime.Now),
                Description = workout.Description,
                FriendsNotes = workout.FriendsNotes,
                Notes = workout.Notes,
                Duration = workout.Duration,
                Finished = workout.Finished,
            };

            return await _workoutRepository.CreateAsync(newWorkout);
        }

        public async Task<List<WorkoutForCalendarDTO>> GetWorkoutForCurrentMonth(int year, int month)
        {
            List<Workout> workouts = await _workoutRepository.GetWorkoutForCurrentMonth(year, month);
            List<WorkoutForCalendarDTO> calendarWorkouts = _mapper.Map<List<WorkoutForCalendarDTO>>(workouts);

            return calendarWorkouts;
        }



    }

}
