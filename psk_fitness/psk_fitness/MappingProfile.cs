using AutoMapper;
using psk_fitness.Data;
using psk_fitness.DTOs;
using psk_fitness.Utilities;
using psk_fitness.DTOs.WorkoutDTOs;
using psk_fitness.Client.DTOs.TopicDTOs;

namespace psk_fitness;

public class MappingProfile : Profile
{
    // Notes: Don't define Collection mappings, they are automatic
    public MappingProfile()
    {
        CreateMap<ExerciseCreateDTO, Exercise>()
            .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => new TimeSpan(
                src.DurationHours ?? 0,
                src.DurationMinutes ?? 0,
                src.DurationSeconds ?? 0
            )));
        CreateMap<Exercise, ExerciseForWorkoutDTO>().ReverseMap();

        CreateMap<Exercise, ExerciseDisplayDTO>()
            .ForMember(dest => dest.DurationSeconds, opt => opt.MapFrom(src => src.Duration.HasValue ? (int?)src.Duration.Value.Hours : null))
            .ForMember(dest => dest.DurationMinutes, opt => opt.MapFrom(src => src.Duration.HasValue ? (int?)src.Duration.Value.Minutes : null))
            .ForMember(dest => dest.DurationHours, opt => opt.MapFrom(src => src.Duration.HasValue ? (int?)src.Duration.Value.Seconds : null));

        CreateMap<TopicDTO, Topic>()
            .ForMember(
                dest => dest.Color,
                opt => opt.MapFrom(src => src.CssColor.ToString()));

        CreateMap<Topic, TopicDTO>()
            .ForMember(
                dest => dest.CssColor,
                opt => opt.MapFrom(src => CssColor.FromString(src.Color)));
        
        CreateMap<Topic, TopicForWorkoutDTO>().ReverseMap();
        CreateMap<TopicFriend, TopicFriendCreateDTO>().ReverseMap();
       
        
        CreateMap<Workout, WorkoutCreateDTO>().ReverseMap();
        CreateMap<Workout, WorkoutForCalendarDTO>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                   .ForMember(dest => dest.Day, opt => opt.MapFrom(src => src.Date.Day)) 
                   .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                   .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
                   .ForMember(dest => dest.Finished, opt => opt.MapFrom(src => src.Finished))
                   .ForMember(dest => dest.ExerciseTitles, opt => opt.MapFrom(src => src.Exercises.Select(e => e.Title).ToList())); ;
    }
}