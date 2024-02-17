using MediatR;

namespace Application.CQRS.PromoCode.Commands;

public record ActivatePromoCodeCommand(int Id) : IRequest;