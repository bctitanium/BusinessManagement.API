using AutoMapper;
using BusinessManagement.Core.Entities;

namespace BusinessManagement.API.DTOs.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Store, StoreDTO>();
            CreateMap<StoreDTO, Store>()
                .ForMember(s => s.Id, opt => opt.Ignore());

            CreateMap<Supplier, SupplierDTO>();
            CreateMap<SupplierDTO, Supplier>()
                .ForMember(ps => ps.Id, opt => opt.Ignore());

            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>()
                .ForMember(p => p.Id, opt => opt.Ignore());
        }
    }
}
