using AutoMapper;
using psk_fitness.Data;
using psk_fitness.DTOs;

namespace psk_fitness;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Topic, TopicDisplayDTO>().ReverseMap();
        CreateMap<Topic, TopicCreateDTO>().ReverseMap();

        CreateMap<ExerciseCreateDTO, Exercise>()
            .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => new TimeSpan(
                src.DurationHours ?? 0,
                src.DurationMinutes ?? 0,
                src.DurationSeconds ?? 0
            )));

        CreateMap<Exercise, ExerciseDisplayDTO>()
            .ForMember(dest => dest.DurationSeconds, opt => opt.MapFrom(src => src.Duration.HasValue ? (int?)src.Duration.Value.Hours : null))
            .ForMember(dest => dest.DurationMinutes, opt => opt.MapFrom(src => src.Duration.HasValue ? (int?)src.Duration.Value.Minutes : null))
            .ForMember(dest => dest.DurationHours, opt => opt.MapFrom(src => src.Duration.HasValue ? (int?)src.Duration.Value.Seconds : null));
    }
}