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
            CreateMap<BillDTO, Bill>();
            CreateMap<BillDTORs, Bill>();
            CreateMap<Bill, BillDTORs>();
            CreateMap<Bill, BillDTO>();
            CreateMap<OrderDTO, Order>();
            CreateMap<OrderDTORs, Order>();
            CreateMap<Order, OrderDTORs>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<CategoryDTORs, Category>();
            CreateMap<Category, CategoryDTORs>();

            CreateMap<Product, ProductDTORs>()
                 .ForMember(des => des.Category,
                opt => opt.MapFrom(opt => opt.Category.Type));
        }
    }
}