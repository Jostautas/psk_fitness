using AutoMapper;
using psk_fitness.Data;
using psk_fitness.DTOs;
using psk_fitness.DTOs.WorkoutDTOs;

namespace psk_fitness;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Topic, TopicDisplayDTO>().ReverseMap();
        CreateMap<Topic, TopicCreateDTO>().ReverseMap();
        CreateMap<Workout, WorkoutCreateDTO>().ReverseMap();

    }
}