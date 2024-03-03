using Application.DTOs.CartItem;
using Application.DTOs.Product;
using Application.DTOs.ProductCategory;
using Application.DTOs.PromoCode;
using Application.DTOs.Purchase;
using Application.DTOs.User;
using Application.DTOs.UserBalance;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ProductCategoryAddDto, ProductCategory>();
        CreateMap<ProductCategory, ProductCategoryGetDto>();

        CreateMap<ProductAddDtoHttp, ProductAddDto>();
        CreateMap<ProductAddDto, Product>();
        CreateMap<Product, ProductGetDto>();
        CreateMap<ProductUpdateDto, Product>();

        CreateMap<UserRegisterDto, User>();
        CreateMap<User, UserGetDto>();

        CreateMap<CartItem, CartItemGetDto>();
        CreateMap<CartItemAddDto, CartItem>();
        CreateMap<CartItemRemoveDto, CartItem>();

        CreateMap<PurchaseAddPostDto, PurchaseAddDto>();
        CreateMap<PurchaseAddDto, Purchase>();
        CreateMap<Purchase, PurchaseResultDto>();
        CreateMap<Purchase, PurchaseGetDto>();

        CreateMap<PromoCodeAddDto, PromoCode>();
        CreateMap<PromoCode, PromoCodeGetDto>();

        CreateMap<UserBalance, GetUserBalanceDto>();
        CreateMap<AddToUserBalanceDto, UserBalance>();
        CreateMap<SubtractFromUserBalanceDto, UserBalance>();
    }
}