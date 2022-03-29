﻿using AutoMapper;
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

            CreateMap<ProductSupplier, ProductSupplierDTO>();
            CreateMap<ProductSupplierDTO, ProductSupplier>()
                .ForMember(ps => ps.Id, opt => opt.Ignore());
        }
    }
}
