using Application.DTOs.Purchase;
using MediatR;

namespace Application.CQRS.Purchase.Queries;

public record GetUserPurchaseListQuery(int UserId) : IRequest<List<PurchaseGetDto>>;