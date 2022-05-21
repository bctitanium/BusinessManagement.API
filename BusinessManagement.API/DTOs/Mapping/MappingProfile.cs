using AutoMapper;
using BusinessManagement.API.DTOs.Create;
using BusinessManagement.Core.Entities;
using BusinessManagement.Core.UserIdentify;

namespace BusinessManagement.API.DTOs.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Store, StoreDTO>()
                .ForMember(s => s.Products, opt => opt.MapFrom(s => s.Products.Select(p => p.Id)));
            CreateMap<StoreDTO, Store>()
                .ForMember(s => s.Id, opt => opt.Ignore());

            CreateMap<Supplier, SupplierDTO>();
            CreateMap<SupplierDTO, Supplier>()
                .ForMember(s => s.Id, opt => opt.Ignore());

            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>()
                .ForMember(p => p.Id, opt => opt.Ignore());

            CreateMap<Brand, BrandDTO>();
            CreateMap<BrandDTO, Brand>()
                .ForMember(b => b.Id, opt => opt.Ignore());

            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            CreateMap<Receipt, ReceiptDTO>();
            CreateMap<ReceiptDTO, Receipt>()
                .ForMember(r => r.Id, opt => opt.Ignore());

            CreateMap<DetailedReceipt, DetailedReceiptDTO>();
            CreateMap<DetailedReceiptDTO, DetailedReceipt>()
                .ForMember(dr => dr.Id, opt => opt.Ignore());

            CreateMap<SupplyProduct, SupplyProductDTO>();
            CreateMap<SupplyProductDTO, SupplyProduct>()
                .ForMember(sp => sp.Id, opt => opt.Ignore());

            CreateMap<User, UserDTO>()
                .ForMember(d => d.Roles, opt => opt.MapFrom(s => s.UserRoles.Select(ur => ur.Role!.Name)));
            CreateMap<UserDTO, User>()
                .ForMember(d => d.Guid, opt => opt.Ignore());
            CreateMap<CreateUserDTO, User>();

            CreateMap<Role, RoleDTO>();
            CreateMap<RoleDTO, Role>()
                .ForMember(d => d.Id, opt => opt.Ignore());

            CreateMap<Customer, CustomerDTO>()
                .ForMember(d => d.Roles, opt => opt.MapFrom(s => s.UserRoles.Select(ur => ur.Role!.Name)));
            CreateMap<CustomerDTO, Customer>()
                .ForMember(d => d.Guid, opt => opt.Ignore());
            CreateMap<CreateUserDTO, Customer>();
            
            CreateMap<Staff, StaffDTO>()
                .ForMember(d => d.Roles, opt => opt.MapFrom(s => s.UserRoles.Select(ur => ur.Role!.Name)));
            CreateMap<StaffDTO, Staff>()
                .ForMember(d => d.Guid, opt => opt.Ignore());
            CreateMap<CreateUserDTO, Staff>();
        }
    }
}
