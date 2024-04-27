using AutoMapper;
using psk_fitness.Data;
using psk_fitness.DTOs;
namespace psk_fitness.Utilities;

public class MappingProfile : Profile
{
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
    }
}