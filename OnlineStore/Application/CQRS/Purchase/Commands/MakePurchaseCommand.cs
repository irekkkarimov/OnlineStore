using Application.DTOs.Purchase;
using MediatR;

namespace Application.CQRS.Purchase.Commands;

public record MakePurchaseCommand(PurchaseAddDto PurchaseAddDto) : IRequest<PurchaseResultDto>;