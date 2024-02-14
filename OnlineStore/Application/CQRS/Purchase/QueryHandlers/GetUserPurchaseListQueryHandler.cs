using Application.Abstractions.Services.ShopServices;
using Application.Abstractions.Services.ShopServices.ValidationServices;
using Application.CQRS.Purchase.Queries;
using Application.DTOs.Purchase;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Purchase.QueryHandlers;

public class GetUserPurchaseListQueryHandler : IRequestHandler<GetUserPurchaseListQuery, List<PurchaseGetDto>>
{
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly IPurchaseValidationService _validationService;
    private readonly IMapper _mapper;

    public GetUserPurchaseListQueryHandler(IPurchaseRepository purchaseRepository,
        IPurchaseValidationService validationService, IMapper mapper)
    {
        _purchaseRepository = purchaseRepository;
        _validationService = validationService;
        _mapper = mapper;
    }

    public async Task<List<PurchaseGetDto>> Handle(GetUserPurchaseListQuery request,
        CancellationToken cancellationToken)
    {
        var userId = request.UserId;
        await _validationService.ValidateGettingByUserIdAsync(userId);

        var userPurchaseList = await _purchaseRepository.GetAllByUserIdAsync(userId);
        var purchaseGetDtoList = userPurchaseList
            .Select(i => _mapper.Map<PurchaseGetDto>(i))
            .ToList();

        return purchaseGetDtoList;
    }
}