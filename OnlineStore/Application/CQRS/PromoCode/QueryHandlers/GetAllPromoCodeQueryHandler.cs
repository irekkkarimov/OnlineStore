using Application.CQRS.PromoCode.Queries;
using Application.DTOs.PromoCode;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.PromoCode.QueryHandlers;

public class GetAllPromoCodeQueryHandler : IRequestHandler<GetAllPromoCodesQuery, List<PromoCodeGetDto>>
{
    private readonly IPromoCodeRepository _promoCodeRepository;
    private readonly IMapper _mapper;

    public GetAllPromoCodeQueryHandler(IPromoCodeRepository promoCodeRepository, IMapper mapper)
    {
        _promoCodeRepository = promoCodeRepository;
        _mapper = mapper;
    }

    public async Task<List<PromoCodeGetDto>> Handle(GetAllPromoCodesQuery request, CancellationToken cancellationToken)
    {
        var allPromoCodes = await _promoCodeRepository.GetAllAsync();
        var promoCodeGetDtos = allPromoCodes
            .Select(i => _mapper.Map<PromoCodeGetDto>(i))
            .ToList();

        return promoCodeGetDtos;
    }
}