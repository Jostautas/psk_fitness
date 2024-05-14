using AutoMapper;
using psk_fitness.Data;
using psk_fitness.DTOs;
using psk_fitness.Utilities;
using psk_fitness.DTOs.WorkoutDTOs;

namespace psk_fitness;

public class MappingProfile : Profile
{
    // Notes: Don't define Collection mappings, they are automatic
    public MappingProfile()
    {
        CreateMap<Topic, TopicDTO>()
            .ForMember(
                dest => dest.CssColor,
                opt => opt.MapFrom(src => CssColor.FromString(src.Color)));
        CreateMap<TopicDTO, Topic>()
            .ForMember(
                dest => dest.Color,
                opt => opt.MapFrom(src => src.CssColor.ToString()));
        CreateMap<Topic, Topic>();
        CreateMap<TopicFriend, TopicFriendCreateDTO>().ReverseMap();
        CreateMap<Workout, WorkoutCreateDTO>().ReverseMap();
    }
}