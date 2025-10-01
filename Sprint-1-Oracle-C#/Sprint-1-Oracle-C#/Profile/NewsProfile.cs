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
    }
}
