using Application.DTOs.CartItem;
using Application.DTOs.Product;
using Application.DTOs.ProductCategory;
using Application.DTOs.Purchase;
using Application.DTOs.User;
using AutoMapper;
using Domain.Entities;

namespace Presentation.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ProductCategoryAddDto, ProductCategory>();
        CreateMap<ProductCategory, ProductCategoryGetDto>();

        CreateMap<ProductAddDto, Product>();
        CreateMap<Product, ProductGetDto>();
        CreateMap<ProductUpdateDto, Product>();

        CreateMap<UserRegisterDto, User>();

        CreateMap<CartItem, CartItemGetDto>();
        CreateMap<CartItemAddDto, CartItem>();
        CreateMap<CartItemRemoveDto, CartItem>();

        CreateMap<PurchaseAddPostDto, PurchaseAddDto>();
        CreateMap<PurchaseAddDto, Purchase>();
    }
}