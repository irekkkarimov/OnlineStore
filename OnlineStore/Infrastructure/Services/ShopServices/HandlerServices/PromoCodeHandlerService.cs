using Application.Abstractions.Services.ShopServices.HandlerServices;
using Application.Abstractions.Services.ShopServices.ValidationServices;
using Application.DTOs.PromoCode;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Services.ShopServices.HandlerServices;

public class PromoCodeHandlerService : IPromoCodeHandlerService
{
    private readonly IPromoCodeRepository _promoCodeRepository;
    private readonly IPromoCodeValidationService _validationService;
    private readonly IMapper _mapper;

    public PromoCodeHandlerService(IPromoCodeRepository promoCodeRepository, IPromoCodeValidationService validationService, IMapper mapper)
    {
        _promoCodeRepository = promoCodeRepository;
        _validationService = validationService;
        _mapper = mapper;
    }

    public async Task Create(PromoCodeAddDto promoCodeAddDto)
    {
        _validationService.ValidateAdding(promoCodeAddDto);
        var promoCode = _mapper.Map<PromoCode>(promoCodeAddDto);
        await _promoCodeRepository.AddAsync(promoCode);
    }

    public Task<bool> Activate(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Activate(string code)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Deactivate(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Deactivate(string code)
    {
        throw new NotImplementedException();
    }

    public Task<bool> TryUse(string code, out double discount)
    {
        throw new NotImplementedException();
    }
}