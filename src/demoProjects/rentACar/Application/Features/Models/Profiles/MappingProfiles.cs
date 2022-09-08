using Application.Features.Models.DTOs;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Models.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Model, ModelListDTO>().ForMember(c=>c.BrandName, 
            opt=>opt.MapFrom(c=>c.Brand.Name)).ReverseMap();
        CreateMap<IPaginate<Model>, ModelListDTO>().ReverseMap();
    }
}