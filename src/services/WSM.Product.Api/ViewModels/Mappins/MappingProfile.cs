using AutoMapper;
using WSM.Catalog.Api.Models;

namespace WSM.Catalog.Api.ViewModels.Mappins;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryViewModel>().ReverseMap();
        CreateMap<Product, ProductViewModel>().ReverseMap();
    }
   
}
