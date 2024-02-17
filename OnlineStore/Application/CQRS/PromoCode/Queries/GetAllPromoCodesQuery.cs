using Application.DTOs.PromoCode;
using MediatR;

namespace Application.CQRS.PromoCode.Queries;

public record GetAllPromoCodesQuery() : IRequest<List<PromoCodeGetDto>>;