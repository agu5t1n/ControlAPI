using AutoMapper;
using ControlApi.DTO;
using ControlAPI.Entities;

namespace ControlApi.Mapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<ProductDTO, Product>();
            CreateMap<ProductDTORs, Product>();
         



            CreateMap<Product, ProductDTORs>()
                 .ForMember(des => des.Category,
                opt => opt.MapFrom(opt => opt.Category.Type));
        }
    }
}
