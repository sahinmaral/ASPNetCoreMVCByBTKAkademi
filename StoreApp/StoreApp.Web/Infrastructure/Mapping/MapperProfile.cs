using AutoMapper;
using Microsoft.AspNetCore.Identity;
using StoreApp.Entities;
using StoreApp.Entities.DTOs;
using StoreApp.Web.Models;

namespace StoreApp.Web.Infrastructure.Mapping;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<ProductCreateViewModel,Product>();
        CreateMap<Product,ProductUpdateViewModel>().ReverseMap();
        CreateMap<UserDtoForCreation,IdentityUser>();
        CreateMap<UserDtoForUpdate,IdentityUser>().ReverseMap();
    }
}