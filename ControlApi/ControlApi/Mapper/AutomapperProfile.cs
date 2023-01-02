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
            //CreateMap<Bill, BillDTORs>()
            //     .ForMember(des => des.NumBill,
            //    opt => opt.MapFrom(opt => opt.NumBill));

            CreateMap<Product, ProductDTORs>()
                 .ForMember(des => des.Category,
                opt => opt.MapFrom(opt => opt.Category.Type));

            //CreateMap<Bill, BillDTORs>().ForMember(
            //  m => m.Date,
            //  opt => opt.MapFrom(src => src.Date.ToString("yyyy-MM-dd"))
            //  );

            //  CreateMap<Bill, BillDTORs>()
            // .ForMember(des => des.NumBill,
            //opt => opt.MapFrom(opt => opt.Order.NumBill));
        }
    }
}
