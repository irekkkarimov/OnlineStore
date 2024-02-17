using Application.DTOs.PromoCode;
using MediatR;

namespace Application.CQRS.PromoCode.Commands;

public record CreatePromoCodeCommand(PromoCodeAddDto PromoCodeAddDto) : IRequest;