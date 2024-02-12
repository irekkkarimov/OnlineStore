using MediatR;

namespace Application.CQRS.ProductCategories.Commands;

public record RemoveProductCategoryCommand(int ProductCategoryId) : IRequest;