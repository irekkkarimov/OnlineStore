using MediatR;

namespace Application.CQRS.PromoCode.Commands;

public record DeactivatePromoCodeCommand(int Id) : IRequest;