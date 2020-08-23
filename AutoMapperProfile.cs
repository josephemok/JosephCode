using AutoMapper;
using JosephCode.Dtos.WolvesDtos;
using JosephCode.Models;
using JosephCode.Dtos.PackDto;

namespace JosephCode
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
           CreateMap<Wolve, GetWolveDto>();
           CreateMap<AddWolveDto, Wolve>();
           CreateMap<Pack, GetWolvePack>();
           CreateMap<GetWolvePack, Pack>();
        }
    }
}