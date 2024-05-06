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
        // TODO: refactor mapping by - same types, different names or for same types
        CreateMap<Topic, TopicDisplayDTO>()
            .ForMember(
                dest => dest.CssColor,
                opt => opt.MapFrom(src => CssColor.FromString(src.Color)));
        CreateMap<TopicDisplayDTO, Topic>()
            .ForMember(
                dest => dest.Color,
                opt => opt.MapFrom(src => src.CssColor.ToString()));
        CreateMap<Topic, TopicCreateDTO>()
            .ForMember(
                dest => dest.CssColor,
                opt => opt.MapFrom(src => CssColor.FromString(src.Color)));
        CreateMap<TopicCreateDTO, Topic>()
            .ForMember(
                dest => dest.Color,
                opt => opt.MapFrom(src => src.CssColor.ToString()));
        CreateMap<TopicFriend, TopicFriendCreateDTO>().ReverseMap();
        CreateMap<Workout, WorkoutCreateDTO>().ReverseMap();
    }
}