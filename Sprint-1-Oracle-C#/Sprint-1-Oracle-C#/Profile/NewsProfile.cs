using AutoMapper;
using Sprint_1_Oracle_C_.Dtos;
using Sprint_1_Oracle_C_.Models;



public class NewsProfile : Profile
{
    public NewsProfile()
    {
        CreateMap<NewsDto, News>()
            .ForMember(desc => desc.CreatedAt, opt => opt.MapFrom(_ => DateTime.Now));

        CreateMap<NewsUpdateDto, News>()
            .ForMember(desc => desc.CreatedAt, opt => opt.MapFrom(_ => DateTime.Now));

        CreateMap<News, NewsResponseDto>();

        CreateMap<News, NewsUpdateDto>();

        CreateMap<NewsUpdateDto, News>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.PublishedAt, opt => opt.Ignore())
             .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                srcMember != null));
    }
}
