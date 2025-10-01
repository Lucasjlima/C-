using AutoMapper;
using Sprint_1_Oracle_C_.Dtos;
using Sprint_1_Oracle_C_.Models;



public class NewsProfile : Profile
{
    public NewsProfile()
    {
        CreateMap<NewsResponseDto, News>();
    }
}
